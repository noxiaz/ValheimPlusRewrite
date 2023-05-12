using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations;

namespace ValheimPlusRewrite.Handlers
{
    public static class CompatibilityHandler
    {
        private static System.Version version = new System.Version(ValheimPlusPlugin.VERSION);
        private static ZPackage serverVersion;

        private static readonly Dictionary<string, ZPackage> clientVersions = new Dictionary<string, ZPackage>();


        [HarmonyPatch(typeof(ZNet), "OnNewConnection")]
        [HarmonyPrefix]
        [HarmonyPriority(800)]
        private static void ZNet_OnNewConnection(ZNet __instance, ZNetPeer peer)
        {
            serverVersion = null;
            peer.m_rpc.Register<ZPackage>("RPC_VP_ReceiveVersionData", RPC_VP_ReceiveVersionData);
        }

        [HarmonyPatch(typeof(ZNet), "RPC_ClientHandshake")]
        [HarmonyPrefix]
        [HarmonyPriority(800)]
        private static void ZNet_RPC_ClientHandshake(ZNet __instance, ZRpc rpc)
        {
            var zPackage = VersionToZPackage(version);
            rpc.Invoke("RPC_VP_ReceiveVersionData", zPackage);
        }

        [HarmonyPatch(typeof(ZNet), "RPC_ServerHandshake")]
        [HarmonyPrefix]
        [HarmonyPriority(800)]
        private static void ZNet_RPC_ServerHandshake(ZNet __instance, ZRpc rpc)
        {
            var zPackage = VersionToZPackage(version);
            rpc.Invoke("RPC_VP_ReceiveVersionData", zPackage);
        }

        [HarmonyPatch(typeof(ZNet), "SendPeerInfo")]
        [HarmonyPrefix]
        [HarmonyPriority(800)]
        private static bool ZNet_SendPeerInfo(ZNet __instance, ZRpc rpc, string password)
        {
            if (ZNet.instance.IsClientInstance() && serverVersion == null)
            {
                //If Client need to verify, then disconnt clint here           
            }

            return true;
        }

        [HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
        [HarmonyPrefix]
        [HarmonyPriority(800)]
        private static bool ZNet_RPC_PeerInfo(ZNet __instance, ZRpc rpc, ZPackage pkg)
        {
            if (ZNet.instance.IsServerInstance())
            {
                Log.LogInfo("Verify version - Clients: " + clientVersions.Count);
                if (Configuration.Current.Server.IsEnabled && Configuration.Current.Server.enforceMod)
                {
                    if (!clientVersions.ContainsKey(rpc.GetSocket().GetEndPointString()))
                    {
                        ZLog.LogWarning("V+ is not installed on the client.");
                        rpc.Invoke("Error", 3);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Store server's message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        private static void RPC_VP_ReceiveVersionData(ZRpc sender, ZPackage data)
        {
            if (ZNet.instance.IsServerInstance())
            {
                clientVersions[sender.m_socket.GetEndPointString()] = data;
                var clientVersion = ReadVersion(data);
                var serverVersion = System.Version.Parse(ValheimPlusPlugin.VERSION);
                ZLog.Log($"Server Version package - From: {sender.m_socket.GetEndPointString()} Version: {clientVersion} Server: {serverVersion}");
                if (Configuration.Current.Server.IsEnabled && Configuration.Current.Server.enforceMod)
                {
                    if (!clientVersion.Equals(serverVersion))
                    {
                        ZLog.LogWarning("Disconnecting client, wrong version");
                        sender.Invoke("Error", 3);
                    }
                }
            }
            else
            {
                CompatibilityHandler.serverVersion = data;
                var serverVersion = ReadVersion(data);
                var clientVersion = System.Version.Parse(ValheimPlusPlugin.VERSION);
                ZLog.Log($"Client Version package - From: {sender.m_socket.GetEndPointString()} Version: {clientVersion} Server: {serverVersion}");
            }
        }

        private static System.Version ReadVersion(ZPackage data)
        {
            data.SetPos(0);
            var version = new System.Version(data.ReadInt(), data.ReadInt(), data.ReadInt(), data.ReadInt());
            return version;
        }

        private static ZPackage VersionToZPackage(System.Version data)
        {
            ZPackage zPackage = new ZPackage();
            zPackage.Write(data.Major);
            zPackage.Write(data.Minor);
            zPackage.Write(data.Build);
            zPackage.Write(data.Revision);
            return zPackage;
        }
    }
}
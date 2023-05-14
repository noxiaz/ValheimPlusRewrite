using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Helpers;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Syncs
{
    [ConfigHandler(typeof(ServerConfiguration))]
    internal static class ConfigSync
    {
        public static bool SyncRemote { get; private set; } = false;


        [HarmonyPatch(typeof(Game), nameof(Game.Start))]
        [HarmonyPrefix]
        private static void Game_Start_Patch()
        {
            ZRoutedRpc.instance.Register("VPlusConfigSync", new Action<long, ZPackage>(RPC_VPlusConfigSync));   
        }

        private static void RPC_VPlusConfigSync(long sender, ZPackage configPkg)
        {
            if (ZNet.instance.IsServer()) //Server
            {
                if (!Configuration.Current.Server.IsEnabled || !Configuration.Current.Server.ServerSyncsConfig) return;

                ZPackage pkg = new ZPackage();
                string[] rawConfigData = File.ReadAllLines(ConfigurationHelper.Path);
                List<string> cleanConfigData = new List<string>();
                for (int i = 0; i < rawConfigData.Length; i++)
                {
                    if (rawConfigData[i].Trim().StartsWith(";") || rawConfigData[i].Trim().StartsWith("#"))
                    {
                        continue; //Skip comments
                    }
                    else if (rawConfigData[i].Trim().IsNullOrWhiteSpace())
                    {
                        continue; //Skip blank lines
                    }
                    else
                    {
                        //Add to clean data
                        cleanConfigData.Add(rawConfigData[i]);
                    }
                }

                //Add number of clean lines to package
                pkg.Write(cleanConfigData.Count);

                //Add each line to the package
                foreach (string line in cleanConfigData)
                {
                    pkg.Write(line);
                }

                ZRoutedRpc.instance.InvokeRoutedRPC(sender, "VPlusConfigSync", new object[]
                {
                    pkg
                });

                Log.LogInfo("VPlus configuration synced to peer #" + sender);
            }
            else //Client
            {
                if (configPkg != null && configPkg.Size() > 0 && sender == ZRoutedRpc.instance.GetServerPeerID()) //Validate the message is from the server and not another client.
                {
                    int numLines = configPkg.ReadInt();
                    if (numLines == 0)
                    {
                        Log.LogWarning("Got zero line config file from server. Cannot load.");
                        return;
                    }

                    try
                    {
                        SyncRemote = true;
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            using (StreamWriter tmpWriter = new StreamWriter(memStream))
                            {
                                for (int i = 0; i < numLines; i++)
                                {
                                    var line = configPkg.ReadString();
                                    tmpWriter.WriteLine(line);
                                }

                                tmpWriter.Flush(); //Flush to memStream
                                memStream.Position = 0; //Rewind stream

                                ValheimPlusPlugin.UnpatchSelf();
                                Configuration.Current = ConfigurationHelper.ReadFromStream(memStream);

                                ValheimPlusPlugin.PatchAll();

                                Log.LogInfo("Successfully synced VPlus configuration from server.");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Log.LogError("Failed to read config from server.");
                        throw;
                    }
                    finally
                    {
                        SyncRemote = false;
                    }
                }
            }
        }
    }
}

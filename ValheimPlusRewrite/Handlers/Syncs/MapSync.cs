using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Handlers.Syncs.Models;
using ValheimPlusRewrite.GameClasses;
using ValheimPlusRewrite.Utilities;
using ValheimPlusRewrite.Utilities.Models;

namespace ValheimPlusRewrite.Handlers.Syncs
{
    [HarmonyPatch]
    public class MapSync
    {
        private static bool[] serverMapData;

        public static bool ShouldSyncOnSpawn { get; set; } = true;


        [HarmonyPatch(typeof(Game), nameof(Game.Start))]
        [HarmonyPrefix]
        private static void Game_Start_Patch()
        {
            ZRoutedRpc.instance.Register("VPlusMapSync", new Action<long, ZPackage>(RPC_VPlusMapSync));
        }

        [HarmonyPatch(typeof(ZNet), "RPC_RefPos")]
        [HarmonyPostfix]
        private static void ZNet_RPC_RefPos(ref ZNet __instance, ZRpc rpc, Vector3 pos, bool publicRefPos)
        {
            if (!__instance.IsServer()) return;

            if (Configuration.Current.Map.IsEnabled && Configuration.Current.Map.shareMapProgression)
            {
                Minimap.instance.WorldToPixel(pos, out int pixelX, out int pixelY);
                int radiusPixels = (int)Mathf.Ceil(Configuration.Current.Map.exploreRadius / Minimap.instance.m_pixelSize);

                for (int y = pixelY - radiusPixels; y <= pixelY + radiusPixels; ++y)
                {
                    for (int x = pixelX - radiusPixels; x <= pixelX + radiusPixels; ++x)
                    {
                        if (x >= 0 && y >= 0 &&
                            (x < Minimap.instance.m_textureSize && y < Minimap.instance.m_textureSize) &&
                            ((double)new Vector2((float)(x - pixelX), (float)(y - pixelY)).magnitude <=
                             (double)radiusPixels))
                        {
                            serverMapData[y * Minimap.instance.m_textureSize + x] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Update exploration for all players
        /// </summary>
        [HarmonyPatch(typeof(Minimap), "UpdateExplore")]
        [HarmonyPrefix]
        private static void Minimap_UpdateExplore(ref float dt, ref Player player, ref Minimap __instance, ref float ___m_exploreTimer, ref float ___m_exploreInterval)
        {
            if (Configuration.Current.Map.exploreRadius > 10000) Configuration.Current.Map.exploreRadius = 10000;

            if (!Configuration.Current.Map.IsEnabled) return;

            if (Configuration.Current.Map.shareMapProgression)
            {
                float explorerTime = ___m_exploreTimer;
                explorerTime += Time.deltaTime;
                if (explorerTime > ___m_exploreInterval)
                {
                    if (ZNet.instance.m_players.Any())
                    {
                        foreach (ZNet.PlayerInfo m_Player in ZNet.instance.m_players)
                        {
                            MinimapHook.call_Explore(__instance, m_Player.m_position, Configuration.Current.Map.exploreRadius);
                        }
                    }
                }
            }

            // Always reveal for your own, we do this non the less to apply the potentially bigger exploreRadius
            MinimapHook.call_Explore(__instance, player.transform.position, Configuration.Current.Map.exploreRadius);
        }

        [HarmonyPatch(typeof(Minimap), "Awake")]
        [HarmonyPostfix]
        private static void Minimap_Awake()
        {
            if (ZNet.m_isServer && Configuration.Current.Map.IsEnabled && Configuration.Current.Map.shareMapProgression)
            {
                //Init map array
                serverMapData = new bool[Minimap.instance.m_textureSize * Minimap.instance.m_textureSize];

                //Load map data from disk
                LoadMapDataFromDisk();

                //Start map data save timer
                ValheimPlusPlugin.mapSyncSaveTimer.Start();
            }
        }

        [HarmonyPatch(typeof(ZNet), "Shutdown")]
        [HarmonyPostfix]
        private static void ZNet_Shutdown(ref ZNet __instance)
        {
            //We left the server, so reset our map sync check.
            if (Configuration.Current.Map.IsEnabled && Configuration.Current.Map.shareMapProgression)
            {
                if (!__instance.IsServer())
                {
                    ShouldSyncOnSpawn = true;
                }
                else
                {
                    SaveMapDataToDisk();
                }
            }
        }

        [HarmonyPatch(typeof(Player), "OnSpawned")]
        [HarmonyPrefix]
        private static void Player_OnSpawned_Patch(ref Player __instance)
        {
            if (ShouldSyncOnSpawn && Configuration.Current.Map.IsEnabled && Configuration.Current.Map.shareMapProgression)
            {
                //Send map data to the server
                SendMapToServer();
                ShouldSyncOnSpawn = false;
            }
        }

        public static void RPC_VPlusMapSync(long sender, ZPackage mapPkg)
        {
            if (ZNet.m_isServer) //Server
            {
                if (sender == ZRoutedRpc.instance.GetServerPeerID()) return;

                if (mapPkg == null) return;

                //Get number of explored areas
                int exploredAreaCount = mapPkg.ReadInt();

                if (exploredAreaCount > 0)
                {
                    //Iterate and add them to server's combined map data.
                    for (int i = 0; i < exploredAreaCount; i++)
                    {
                        MapRangeModel exploredArea = mapPkg.ReadMapRange();

                        for (int x = exploredArea.StartingX; x < exploredArea.EndingX; x++)
                        {
                            serverMapData[exploredArea.Y * Minimap.instance.m_textureSize + x] = true;
                        }
                    }

                    Log.LogInfo($"Received {exploredAreaCount} map ranges from peer #{sender}.");

                    //Send Ack
                    SendAck(sender);
                }

                //Check if this is the last chunk from the client.
                bool lastMapPackage = mapPkg.ReadBool();

                if (!lastMapPackage) return; //This package is one of many chunks, so don't update clients until we get all of them.

                //Convert map data into ranges
                List<MapRangeModel> serverExploredAreas = ExplorationDataToMapRanges(serverMapData);

                //Chunk up the map data
                List<ZPackage> packages = ChunkMapData(serverExploredAreas);

                //Send the updated server map to all clients
                foreach (ZPackage pkg in packages)
                {
                    RpcQueue.Enqueue(new RpcDataModel()
                    {
                        Name = "VPlusMapSync",
                        Payload = new object[] { pkg },
                        Target = ZRoutedRpc.Everybody
                    });
                }

                Log.LogInfo($"-------------------------- Packages: {packages.Count}");

                Log.LogInfo($"Sent map updates to all clients ({serverExploredAreas.Count} map ranges, {packages.Count} chunks)");
            }
            else //Client
            {
                if (sender != ZRoutedRpc.instance.GetServerPeerID()) return; //Only bother if it's from the server.

                if (mapPkg == null)
                {
                    Log.LogWarning("Warning: Got empty map sync package from server.");
                    return;
                }

                //Get number of explored areas
                int exploredAreaCount = mapPkg.ReadInt();

                if (exploredAreaCount > 0)
                {
                    //Iterate and add them to explored map
                    for (int i = 0; i < exploredAreaCount; i++)
                    {
                        MapRangeModel exploredArea = mapPkg.ReadMapRange();

                        for (int x = exploredArea.StartingX; x < exploredArea.EndingX; x++)
                        {
                            Minimap.instance.Explore(x, exploredArea.Y);
                        }
                    }

                    //Update fog texture
                    Minimap.instance.m_fogTexture.Apply();

                    Log.LogInfo($"I got {exploredAreaCount} map ranges from the server!");

                    //Send Ack
                    SendAck(sender);
                }
                else
                {
                    Log.LogInfo("Server has no explored areas to sync, continuing.");
                }
            }
        }

        public static void SendMapToServer()
        {
            Log.LogInfo("-------------------- SENDING VPLUSMAPSYNC DATA");

            //Convert exploration data to ranges
            List<MapRangeModel> exploredAreas = ExplorationDataToMapRanges(Minimap.instance.m_explored);

            //If we have no data to send, just send an empty RPC to trigger the server end to sync.
            if (exploredAreas.Count == 0)
            {
                ZPackage pkg = new ZPackage();

                pkg.Write(0); //Number of explored areas we're sending (zero in this case)
                pkg.Write(true); //Trigger server sync by telling the server this is the last package we'll be sending.

                ZRoutedRpc.instance.InvokeRoutedRPC(ZRoutedRpc.instance.GetServerPeerID(), "VPlusMapSync",
                    new object[] { pkg });
            }
            else //We have data to send. Prep it and send it.
            {
                //Chunk map data
                List<ZPackage> packages = ChunkMapData(exploredAreas);

                //Route all chunks to the server
                foreach (ZPackage pkg in packages)
                {
                    RpcQueue.Enqueue(new RpcDataModel()
                    {
                        Name = "VPlusMapSync",
                        Payload = new object[] { pkg },
                        Target = ZRoutedRpc.instance.GetServerPeerID()
                    });
                }

                Log.LogInfo($"Sent my map data to the server ({exploredAreas.Count} map ranges, {packages.Count} chunks)");
            }
        }

        public static void LoadMapDataFromDisk()
        {
            //TODO: Optimize / Improve on disk format for exploration data. (JSON?)

            if (serverMapData == null) return;

            //Load map data
            if (File.Exists(ValheimPlusPlugin.DataDirectoryPath +
                            Path.DirectorySeparatorChar +
                            ZNet.instance.GetWorldName() + "_mapSync.dat"))
            {
                try
                {
                    string mapData = File.ReadAllText(ValheimPlusPlugin.DataDirectoryPath +
                                                      Path.DirectorySeparatorChar +
                                                      ZNet.instance.GetWorldName() + "_mapSync.dat");

                    string[] dataPoints = mapData.Split(',');

                    foreach (string dataPoint in dataPoints)
                    {
                        if (int.TryParse(dataPoint, out int result))
                        {
                            serverMapData[result] = true;
                        }
                    }

                    Log.LogInfo($"Loaded {dataPoints.Length} map points from disk.");
                }
                catch (Exception ex)
                {
                    Log.LogError("Failed to load synchronized map data.");
                    Log.LogError(ex);
                }
            }
        }

        public static void SaveMapDataToDisk()
        {
            //TODO: Optimize / Improve on disk format for exploration data. (JSON?)

            if (serverMapData == null) return;

            List<int> mapDataToDisk = new List<int>();

            for (int y = 0; y < Minimap.instance.m_textureSize; ++y)
            {
                for (int x = 0; x < Minimap.instance.m_textureSize; ++x)
                {
                    if (serverMapData[y * Minimap.instance.m_textureSize + x])
                    {
                        mapDataToDisk.Add(y * Minimap.instance.m_textureSize + x);
                    }
                }
            }

            if (mapDataToDisk.Count > 0)
            {
                File.Delete(ValheimPlusPlugin.DataDirectoryPath +
                            Path.DirectorySeparatorChar +
                            ZNet.instance.GetWorldName() + "_mapSync.dat");
                File.WriteAllText(ValheimPlusPlugin.DataDirectoryPath +
                                  Path.DirectorySeparatorChar +
                                  ZNet.instance.GetWorldName() + "_mapSync.dat", string.Join(",", mapDataToDisk));

                Log.LogInfo($"Saved {mapDataToDisk.Count} map points to disk.");
            }
        }

        private static List<MapRangeModel> ExplorationDataToMapRanges(bool[] explorationData)
        {
            //Iterate the explored map and convert to ranges
            List<MapRangeModel> exploredAreas = new List<MapRangeModel>();

            for (int y = 0; y < Minimap.instance.m_textureSize; ++y)
            {
                int startX = -1, endX = -1;

                for (int x = 0; x < Minimap.instance.m_textureSize; ++x)
                {
                    //Find the first X value that is true
                    if (explorationData[y * Minimap.instance.m_textureSize + x] && startX == -1 && endX == -1)
                    {
                        startX = x;
                        continue;
                    }

                    //Find the last X value that is true
                    if (!explorationData[y * Minimap.instance.m_textureSize + x] && startX > -1 && endX == -1)
                    {
                        endX = x - 1;
                        continue;
                    }

                    //If we have both X values in the range, save it for this Y value.
                    if (startX > -1 && endX > -1)
                    {
                        exploredAreas.Add(new MapRangeModel()
                        {
                            StartingX = startX,
                            EndingX = endX,
                            Y = y
                        });

                        startX = -1;
                        endX = -1;
                    }
                }

                //If we got a starting X coordinate but never got an end coordinate, this range is completely explored.
                if (startX > -1 && endX == -1)
                {
                    //The row is true til the end, create a range for it.
                    exploredAreas.Add(new MapRangeModel()
                    {
                        StartingX = startX,
                        EndingX = Minimap.instance.m_textureSize,
                        Y = y
                    });
                }
            }

            return exploredAreas;
        }

        private static List<ZPackage> ChunkMapData(List<MapRangeModel> mapData, int chunkSize = 10000)
        {
            if (mapData == null || mapData.Count == 0) return null;

            //Chunk the map data into pieces based on the maximum possible map data
            List<List<MapRangeModel>> chunkedData = mapData.ChunkBy(chunkSize);
            List<ZPackage> packageList = new List<ZPackage>();

            //Iterate the chunks
            foreach (List<MapRangeModel> thisChunk in chunkedData)
            {
                ZPackage pkg = new ZPackage();

                //Write number of MapRanges in this package
                pkg.Write(thisChunk.Count);

                //Write each MapRange in this chunk to this package.
                foreach (MapRangeModel mapRange in thisChunk)
                {
                    pkg.WriteMapRange(mapRange);
                }

                //Write boolean dictating if this is the last chunk in the ZPackage sequence
                if (thisChunk == chunkedData.Last())
                {
                    pkg.Write(true);
                }
                else
                {
                    pkg.Write(false);
                }

                //Add the package to the package list
                packageList.Add(pkg);
            }

            return packageList;
        }

        private static void RPC_VPlusAck(long sender)
        {
            RpcQueue.GotAck();
        }

        private static void SendAck(long target)
        {
            ZRoutedRpc.instance.InvokeRoutedRPC(target, "VPlusAck");
        }
    }
}

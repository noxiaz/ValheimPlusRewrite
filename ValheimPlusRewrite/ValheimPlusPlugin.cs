using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Helpers;
using ValheimPlusRewrite.Handlers.Menu;
using ValheimPlusRewrite.Handlers.Syncs;
using ValheimPlusRewrite.Handlers;
using System.Reflection;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite
{
    [BepInPlugin("org.bepinex.plugins.valheim_plus", "Valheim Plus", VERSION)]
    public class ValheimPlusPlugin : BaseUnityPlugin
    {
        public const string VERSION = "0.9.9.16";
        internal static System.Timers.Timer mapSyncSaveTimer = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
        private static Harmony harmony = new Harmony("mod.valheim_plus");

        internal static string DataDirectoryPath { get; private set; } = Path.Combine(Paths.BepInExRootPath, "vplus-data");
        internal static ValheimPlusPlugin Instance { get; private set; }

        void Awake()
        {
            Instance = this;
            Log.Initialize(base.Logger);
            Log.LogDebug($"Total MODs installed: {BepInEx.Bootstrap.Chainloader.PluginInfos.Count}");
            foreach (var item in BepInEx.Bootstrap.Chainloader.PluginInfos)
            {
                Log.LogDebug(item.Key);
            }

            Log.LogInfo("Trying to load the configuration file");
            if (ConfigurationHelper.LoadSettings() != true)
            {
                Log.LogError("Error while loading configuration file.");
            }
            else
            {
                Log.LogInfo("Configuration file loaded succesfully.");
                PatchAll();

                if (!Directory.Exists(DataDirectoryPath))
                {
                    Directory.CreateDirectory(DataDirectoryPath);
                }

                //Map Sync Save Timer
                if (ZNet.instance.IsServer())// && Configuration.Current.Map.IsEnabled && Configuration.Current.Map.ShareMapProgression)
                {
                    mapSyncSaveTimer.AutoReset = true;
                    mapSyncSaveTimer.Elapsed += (sender, args) => MapSync.SaveMapDataToDisk();
                }
            }
        }

        public static void PatchAll()
        {
            harmony.PatchAll();
            var classesToPatch = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypesWithAttribute(typeof(ConfigHandler)));
            var configType = typeof(Configuration);
            foreach (var item in classesToPatch)
            {
                var customAttribute = item.GetCustomAttribute<ConfigHandler>();
                var targetType = customAttribute.TargetType;
                var property = configType.GetProperties().FirstOrDefault(x => x.PropertyType == targetType);
                var configurationSection = property?.GetValue(Configuration.Current) as BaseConfig;
                if ((configurationSection?.IsEnabled).GetValueOrDefault())
                {
                    harmony.PatchAll(item);
                }
            }
        }

        public static void UnpatchSelf()
        {
            harmony.UnpatchSelf();
        }
    }
}

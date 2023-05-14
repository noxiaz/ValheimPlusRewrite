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
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class ValheimPlusPlugin : BaseUnityPlugin
    {
        internal const string PLUGIN_NAME = "Valheim Plus";
        internal const string PLUGIN_GUID = "mod.valheim_plus";
        internal const string PLUGIN_VERSION = "0.9.9.16";
        private static Harmony harmony = new Harmony(PLUGIN_GUID);

        internal static string DataDirectoryPath { get; private set; } = Path.Combine(Paths.BepInExRootPath, "vplus-data");
        internal static ValheimPlusPlugin Instance { get; private set; }

        private void Awake()
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
                if (!Directory.Exists(DataDirectoryPath))
                {
                    Directory.CreateDirectory(DataDirectoryPath);
                }

                PatchAll();
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
                var settingProperty = configType.GetProperties().FirstOrDefault(x => x.PropertyType == targetType);
                var configurationSection = settingProperty?.GetValue(Configuration.Current) as BaseConfig;
                if ((configurationSection?.IsEnabled).GetValueOrDefault())
                {
                    if (customAttribute.PropertyName != null)
                    {
                        var propertyValue = configurationSection.GetPropertyValue(customAttribute.PropertyName);
                        var isDefault = (bool)propertyValue.GetPropertyValue("IsDefault");
                        if (!isDefault)
                        {
                            Log.LogDebug($"Patching - Name: {item.Name}");
                            harmony.PatchAll(item);
                        }
                        else
                        {
                            Log.LogDebug($"Patching stopped - Name: {item.Name} Property: {customAttribute.PropertyName} - Property has default value");
                        }
                    }
                    else
                    {
                        Log.LogDebug($"Patching - Name: {item.Name}");
                        harmony.PatchAll(item);
                    }
                }
                else
                {
                    Log.LogDebug($"Patching stopped - Name: {item.Name} - Section not enabled");
                }
            }
        }

        public static void UnpatchSelf()
        {
            harmony.UnpatchSelf();
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }
}

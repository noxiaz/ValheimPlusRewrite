using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations.Helpers;
using ValheimPlusRewrite.Handlers;
using ValheimPlusRewrite.UI;

namespace ValheimPlusRewrite
{
    [BepInPlugin("org.bepinex.plugins.valheim_plus", "Valheim Plus", VERSION)]
    public class ValheimPlusPlugin : BaseUnityPlugin
    {
        public const string VERSION = "0.9.9.16";
        private static Harmony harmony = new Harmony("mod.valheim_plus");

        internal static readonly string VPlusDataDirectoryPath = Path.Combine(Paths.BepInExRootPath, "vplus-data");
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
                VPlusMainMenu.Load();
            }
        }

        public static void PatchAll()
        {
            harmony.PatchAll(typeof(CompatibilityHandler));
            harmony.PatchAll();
        }

        public static void UnpatchSelf()
        {
            harmony.UnpatchSelf();
        }
    }
}

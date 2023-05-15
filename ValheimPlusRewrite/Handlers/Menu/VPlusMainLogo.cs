using HarmonyLib;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;
using ValheimPlusRewrite.Utilities;

namespace ValheimPlusRewrite.Handlers.Menu
{
    [ConfigHandler(typeof(ValheimPlusConfiguration))]
    public static class VPlusMainLogo
    {
        public static Sprite VPlusLogoSprite;

        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
        [HarmonyPostfix]
        public static void FejdStartup_Awake_Postfix()
        {
            Load();
        }

        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.SetupGui))]
        [HarmonyPostfix]
        public static void FejdStartup_SetupGui_Postfix(ref FejdStartup __instance)
        {
            if (Configuration.Current.ValheimPlus.IsEnabled && Configuration.Current.ValheimPlus.MainMenuLogo)
            {
                Log.LogInfo("Going to load logo");
                GameObject logo = GameObject.Find("LOGO");
                logo.GetComponent<Image>().sprite = VPlusLogoSprite;
            }
        }

        private static void Load()
        {
            //Load the logo from embedded asset
            Stream logoStream = EmbeddedAsset.LoadEmbeddedAsset("logo.png");
            Texture2D logoTexture = EmbeddedAsset.LoadPng(logoStream);
            VPlusLogoSprite = Sprite.Create(logoTexture, new Rect(0, 0, logoTexture.width, logoTexture.height), new Vector2(0.5f, 0.5f));
            logoStream.Dispose();
        }
    }
}

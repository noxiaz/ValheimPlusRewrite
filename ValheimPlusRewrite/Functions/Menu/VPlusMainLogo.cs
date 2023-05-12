using HarmonyLib;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Utilities;

namespace ValheimPlusRewrite.Functions.Menu
{
    [HarmonyPatch]
    public static class VPlusMainLogo
    {
        public static Sprite VPlusLogoSprite;

        [HarmonyPatch(typeof(FejdStartup), "Awake")]
        [HarmonyPostfix]
        public static void FejdStartup_Awake_Patch()
        {
            Load();
        }

        [HarmonyPatch(typeof(FejdStartup), "SetupGui")]
        [HarmonyPostfix]
        public static void FejdStartup_SetupGui_Patch(ref FejdStartup __instance)
        {
            if (Configuration.Current.ValheimPlus.IsEnabled && Configuration.Current.ValheimPlus.mainMenuLogo)
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

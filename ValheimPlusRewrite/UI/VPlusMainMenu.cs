using HarmonyLib;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Utilities;

namespace ValheimPlusRewrite.UI
{
    [HarmonyPatch]
    public static class VPlusMainMenu
    {
        public static Sprite VPlusLogoSprite;
        public static Sprite VPlusBannerSprite;
        public static Sprite VPlusBannerHoverSprite;

        public static void Load()
        {
            //Load the logo from embedded asset
            Stream logoStream = EmbeddedAsset.LoadEmbeddedAsset("Assets.logo.png");
            Texture2D logoTexture = EmbeddedAsset.LoadPng(logoStream);
            VPlusLogoSprite = Sprite.Create(logoTexture, new Rect(0, 0, logoTexture.width, logoTexture.height), new Vector2(0.5f, 0.5f));
            logoStream.Dispose();

            //Load the banner from embedded asset
            Stream bannerStream = EmbeddedAsset.LoadEmbeddedAsset("Assets.ZapHosting.png");
            Texture2D bannerTexture = EmbeddedAsset.LoadPng(bannerStream);
            VPlusBannerSprite = Sprite.Create(bannerTexture, new Rect(0, 0, bannerTexture.width, bannerTexture.height), new Vector2(0.5f, 0.5f));
            bannerStream.Dispose();

            //Load the bannerfrom embedded asset
            Stream bannerHoverStream = EmbeddedAsset.LoadEmbeddedAsset("Assets.ZapHosting_hover.png");
            Texture2D bannerHoverTexture = EmbeddedAsset.LoadPng(bannerHoverStream);
            VPlusBannerHoverSprite = Sprite.Create(bannerHoverTexture, new Rect(0, 0, bannerHoverTexture.width, bannerHoverTexture.height), new Vector2(0.5f, 0.5f));
            bannerHoverStream.Dispose();            
        }

        [HarmonyPatch(typeof(FejdStartup), "SetupGui")]
        [HarmonyPostfix]
        public static void FejdStartup_SetupGui_Patch(ref FejdStartup __instance)
        {
            if (Configuration.Current.ValheimPlus.IsEnabled && Configuration.Current.ValheimPlus.mainMenuLogo)
            {
                Log.LogInfo("Going to load logo");
                GameObject logo = GameObject.Find("LOGO");
                logo.GetComponent<Image>().sprite = VPlusMainMenu.VPlusLogoSprite;
            }
        }
    }
}

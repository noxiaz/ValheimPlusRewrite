using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Huds
{
    [ConfigHandler(typeof(HudConfiguration), nameof(HudConfiguration.RemoveDamageFlash))]
    internal static class DamageFlash
    {
        [HarmonyPatch(typeof(Hud), nameof(Hud.DamageFlash))]
        [HarmonyPostfix]
        private static void Hud_DamageFlash_Postfix(Hud __instance)
        {
            if (Configuration.Current.Hud.IsEnabled && Configuration.Current.Hud.RemoveDamageFlash)
            {
                __instance.m_damageScreen.gameObject.SetActive(false);
            }
        }
    }
}

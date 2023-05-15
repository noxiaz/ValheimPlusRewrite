using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Armors
{
    [ConfigHandler(typeof(ArmorConfiguration))]
    internal static class ArmorHandler
    {
        [HarmonyPatch(typeof(ItemDrop.ItemData), nameof(ItemDrop.ItemData.GetArmor), new System.Type[] { typeof(int) })]
        [HarmonyPrefix]
        private static bool ItemDrop_GetArmor_Prefix(ref ItemDrop.ItemData __instance, ref int quality, ref float __result)
        {
            if (!Configuration.Current.Armor.IsEnabled)
            {
                return true;
            }
            else
            {
                float armor = __instance.m_shared.m_armor + (float)Mathf.Max(0, quality - 1) * __instance.m_shared.m_armorPerLevel;
                __result = armor;

                float modifiedArmorValue = armor;
                switch (__instance.m_shared.m_itemType)
                {
                    case ItemDrop.ItemData.ItemType.Helmet:
                        modifiedArmorValue = modifiedArmorValue.ApplyProcentage(Configuration.Current.Armor.Helmets);
                        break;
                    case ItemDrop.ItemData.ItemType.Chest:
                        modifiedArmorValue = modifiedArmorValue.ApplyProcentage(Configuration.Current.Armor.Chests);
                        break;
                    case ItemDrop.ItemData.ItemType.Legs:
                        modifiedArmorValue = modifiedArmorValue.ApplyProcentage(Configuration.Current.Armor.Legs);
                        break;
                    case ItemDrop.ItemData.ItemType.Shoulder:
                        modifiedArmorValue = modifiedArmorValue.ApplyProcentage(Configuration.Current.Armor.Capes);
                        break;
                    default:
                        break;
                }

                if (modifiedArmorValue != armor)
                    __result = modifiedArmorValue;

                return false;
            }
        }
    }
}

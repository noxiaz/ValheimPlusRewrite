using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Huds
{
    [ConfigHandler(typeof(HudConfiguration), nameof(HudConfiguration.ShowRequiredItems))]
    internal static class RequiredItems
    {
        [HarmonyPatch(typeof(InventoryGui), nameof(InventoryGui.SetupRequirement))]
        [HarmonyPrefix]
        private static bool InventoryGui_SetupRequirement_Patch(Transform elementRoot, Piece.Requirement req, Player player, bool craft, int quality, ref bool __result)
        {
            if (!Configuration.Current.Hud.IsEnabled || !Configuration.Current.Hud.ShowRequiredItems)
            {
                return true;
            }
            else 
            {
                Image component = elementRoot.transform.Find("res_icon").GetComponent<Image>();
                Text component2 = elementRoot.transform.Find("res_name").GetComponent<Text>();
                Text component3 = elementRoot.transform.Find("res_amount").GetComponent<Text>();
                UITooltip component4 = elementRoot.GetComponent<UITooltip>();
                if (req.m_resItem != null)
                {
                    component.gameObject.SetActive(true);
                    component2.gameObject.SetActive(true);
                    component3.gameObject.SetActive(true);
                    component.sprite = req.m_resItem.m_itemData.GetIcon();
                    component.color = Color.white;
                    component4.m_text = Localization.instance.Localize(req.m_resItem.m_itemData.m_shared.m_name);
                    component2.text = Localization.instance.Localize(req.m_resItem.m_itemData.m_shared.m_name);
                    int num = player.GetInventory().CountItems(req.m_resItem.m_itemData.m_shared.m_name);
                    int amount = req.GetAmount(quality);
                    if (amount <= 0)
                    {
                        InventoryGui.HideRequirement(elementRoot);
                        __result = false;
                        return false;
                    }

                    component3.text = num + "/" + amount.ToString();
                    if (num < amount)
                    {
                        component3.color = ((Mathf.Sin(Time.time * 10f) > 0f) ? Color.red : Color.white);
                    }
                    else
                    {
                        component3.color = Color.white;
                    }

                    component3.fontSize = 14;
                    if (component3.text.Length > 5)
                    {
                        component3.fontSize -= component3.text.Length - 5;
                    }
                }

                __result = true;
                return false; 
            }
        }
    }
}

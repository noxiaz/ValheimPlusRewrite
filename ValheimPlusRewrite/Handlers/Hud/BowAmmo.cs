using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Hud
{
    [ConfigHandler(typeof(HudConfiguration), nameof(HudConfiguration.DisplayBowAmmoCounts))]
    internal static class BowAmmo
    {
        private const string hudObjectNameTag = "BowAmmoCounts";
        private const string noAmmoDisplay = "No Ammo";
        private static Dictionary<int, GameObject> ammoCounters = new Dictionary<int, GameObject>();

        [HarmonyPatch(typeof(HotkeyBar), nameof(HotkeyBar.UpdateIcons))]
        [HarmonyPostfix]
        private static void HotkeyBar_UpdateIcons_Patch(ref HotkeyBar __instance, ref Player player)
        {
            if (Configuration.Current.Hud.IsEnabled && Configuration.Current.Hud.DisplayBowAmmoCounts > 0)
            {
                DisplayAmmoCountsUnderBowHotbarIcon(__instance, player);
            }
        }

        private static void DisplayAmmoCountsUnderBowHotbarIcon(HotkeyBar __instance, Player player)
        {
            var hotkeyBarID = __instance.GetInstanceID();
            GameObject ammoCounter = null;
            if (ammoCounters.ContainsKey(hotkeyBarID))
            {
                ammoCounter = ammoCounters[hotkeyBarID];
            }

            // Find the first bow in the hotbar
            ItemDrop.ItemData bow = __instance.m_items.FirstOrDefault(x => x.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Bow);
            if (bow == null) //If no bow in Hotkey bar dont continue
            {
                if (ammoCounter != null && ammoCounter.activeSelf)
                {
                    ammoCounter.SetActive(false);
                }
            }
            else if (Configuration.Current.Hud.DisplayBowAmmoCounts == 1 && !player.IsItemEquiped(bow)) //If bow is not equiped in hotkeybar and settings 1 - Dont continue
            {
                if (ammoCounter != null && ammoCounter.activeSelf)
                {
                    ammoCounter.SetActive(false);
                }
            }
            else if (__instance.m_elements.Count >= bow.m_gridPos.x && bow.m_gridPos.x >= 0)
            {
                // Create a new text element to display the ammo counts
                HotkeyBar.ElementData element = __instance.m_elements[bow.m_gridPos.x];
                Text ammoText;
                if (ammoCounter == null)
                {
                    ammoCounter = GameObject.Instantiate(element.m_amount.gameObject, element.m_amount.gameObject.transform.parent, false);
                    ammoCounter.name = hudObjectNameTag + "-" + hotkeyBarID;
                    ammoCounter.SetActive(true);
                    ammoCounter.transform.SetParent(element.m_amount.gameObject.transform.parent, false);
                    ammoCounter.transform.Translate(new Vector3(0, 42, 0));
                    ammoText = ammoCounter.GetComponent<Text>();
                    ammoText.fontSize -= 2;
                    ammoText.enabled = true;
                    ammoCounters.Add(hotkeyBarID, ammoCounter);
                }
                else
                {
                    ammoCounter.transform.SetParent(element.m_amount.gameObject.transform.parent, false);
                    ammoCounter.SetActive(true);
                    ammoText = ammoCounter.GetComponent<Text>();
                    ammoText.enabled = true;
                }

                // Find the active ammo being used for thebow
                ItemDrop.ItemData ammoItem = player.m_ammoItem;
                if (ammoItem == null)
                    ammoItem = player.GetInventory().GetAmmoItem(bow.m_shared.m_ammoType);

                // Calculate totals to display for current ammo type and all types
                int currentAmmo = 0;
                int totalAmmo = 0;
                var inventoryItems = player.GetInventory().GetAllItems();
                foreach (ItemDrop.ItemData inventoryItem in inventoryItems)
                {
                    if (inventoryItem.m_shared.m_ammoType == bow.m_shared.m_ammoType &&
                        (inventoryItem.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Ammo || inventoryItem.m_shared.m_itemType == ItemDrop.ItemData.ItemType.Consumable))
                    {
                        totalAmmo += inventoryItem.m_stack;

                        if (inventoryItem.m_shared.m_name == ammoItem.m_shared.m_name)
                            currentAmmo += inventoryItem.m_stack;
                    }
                }

                // Change the visual display text for the UI
                if (totalAmmo == 0)
                {
                    ammoText.text = noAmmoDisplay;
                }
                else
                {
                    ammoText.text = ammoItem.m_shared.m_name.Split('_').Last() + "\n" + currentAmmo + "/" + totalAmmo;
                }
            }
        }
    }
}

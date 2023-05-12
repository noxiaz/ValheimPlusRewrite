﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using IniParser;
using IniParser.Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Helpers;
using ValheimPlusRewrite.Utilities;

namespace ValheimPlusRewrite.Functions.Menu
{
    [HarmonyPatch]
    public static class VPlusSettingEditor
    {
        private static bool haveAddedModMenu = false;
        private static GameObject modSettingsPanel = null;
        private static GameObject modSettingsPanelCloner = null;
        private static AssetBundle modSettingsBundle = null;
        private static GameObject enableToggle = null;
        private static Font norseFont;
        private static Color32 vplusYellow = new Color32(255, 164, 0, 255);
        private static GameObject settingsContentPanel;
        private static Dictionary<string, List<GameObject>> settingFamillySettings;
        private static Button applyButton;
        private static Button okButton;
        private static Dropdown dropper;
        private static GameObject uiTooltipPrefab = null;
        private static string[] keycodeNames;
        private static List<string> availableSettings;
        static Transform newStart = null;

        [HarmonyPatch(typeof(FejdStartup), "Update")]
        [HarmonyPostfix]
        public static void FejdStartup_SetupGui_Patch(ref GameObject ___m_mainMenu, ref GameObject ___m_settingsPrefab)
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                if (newStart == null && !VPlusSettingEditor.haveAddedModMenu)
                {
                    bool FindAndAddSettings(Transform parent, Transform current)
                    {
                        if (current.name == "Start game" && !VPlusSettingEditor.haveAddedModMenu)
                        {
                            newStart = GameObject.Instantiate(current);
                            newStart.name = "V+ Settings";
                            newStart.SetParent(parent);
                            newStart.SetSiblingIndex(3);
                            newStart.localScale = current.localScale;

                            var prevText = current.GetComponentInChildren<TextMeshProUGUI>();
                            var newText = newStart.GetComponentInChildren<TextMeshProUGUI>();
                            newText.SetText("V+ Settings");

                            GameObject.DestroyImmediate(newStart.gameObject.GetComponent<Button>());
                            Button newButton = newStart.gameObject.AddComponent<Button>();
                            newButton.transition = Selectable.Transition.Animation;
                            newButton.onClick.AddListener(() => VPlusSettingEditor.Show());

                            VPlusSettingEditor.haveAddedModMenu = true;
                            return true;
                        }

                        foreach (Transform child in current)
                        {
                            if (FindAndAddSettings(current, child))
                            {
                                return true;
                            }
                        }

                        return false;
                    }

                    FindAndAddSettings(null, ___m_mainMenu.transform);
                }
                else
                {
                    VPlusSettingEditor.haveAddedModMenu = false;
                }
            }
        }


        private static GameObject CreateEnableToggle(string settingName, string value, Transform parent, string comments)
        {
            bool currentVal = bool.Parse(value);
            GameObject enableToggleThis = GameObject.Instantiate(enableToggle);
            enableToggleThis.AddComponent<UITooltip>().m_tooltipPrefab = uiTooltipPrefab;
            enableToggleThis.GetComponent<UITooltip>().Set($"{settingName}", comments);
            enableToggleThis.GetComponentInChildren<Toggle>().isOn = currentVal;
            enableToggleThis.transform.SetParent(parent, false);
            enableToggleThis.SetActive(false);
            return enableToggleThis;
        }

        private static GameObject CreateTextSettingEntry(string name, string value, Transform parent, string comments)
        {
            GameObject settingName = GameObject.Instantiate(modSettingsBundle.LoadAsset<GameObject>("SettingEntry_Text"));
            settingName.name = name;
            settingName.transform.GetChild(0).GetComponent<Text>().text = $"Setting: {name}\nCurrent value: {value}";
            settingName.transform.SetParent(parent, false);
            settingName.AddComponent<UITooltip>().m_tooltipPrefab = uiTooltipPrefab;
            settingName.GetComponent<UITooltip>().Set($"{name}", comments);
            settingName.SetActive(false);
            return settingName;
        }

        private static GameObject CreateKeyCodeSettingEntry(string name, string value, Transform parent, string comments)
        {
            GameObject settingName = GameObject.Instantiate(modSettingsBundle.LoadAsset<GameObject>("SettingEntry_KeyCode"));
            settingName.name = name;
            settingName.transform.GetChild(0).GetComponent<Text>().text = $"Setting: {name}";
            settingName.transform.SetParent(parent, false);
            Dropdown dropper = settingName.GetComponentInChildren<Dropdown>();
            dropper.options.Clear();
            foreach (string key in keycodeNames)
            {
                dropper.options.Add(new Dropdown.OptionData(key));
            }

            dropper.value = keycodeNames.ToList().IndexOf(value);
            settingName.AddComponent<UITooltip>().m_tooltipPrefab = uiTooltipPrefab;
            settingName.GetComponent<UITooltip>().Set($"{name}", comments);
            settingName.SetActive(false);
            return settingName;
        }

        private static GameObject CreateBoolSettingEntry(string name, string value, Transform parent, string comments)
        {
            GameObject settingName = GameObject.Instantiate(modSettingsBundle.LoadAsset<GameObject>("SettingEntry_Toggle"));
            settingName.name = name;
            settingName.AddComponent<UITooltip>().m_tooltipPrefab = uiTooltipPrefab;
            settingName.GetComponent<UITooltip>().Set($"{name}", comments);
            settingName.transform.GetChild(0).GetComponent<Text>().text = $"Setting: {name}";
            settingName.GetComponentInChildren<Toggle>().isOn = bool.Parse(value);
            settingName.transform.SetParent(parent, false);
            settingName.GetComponentInChildren<Toggle>().gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, -12.5f, 0);
            settingName.SetActive(false);
            return settingName;
        }

        private static void Load()
        {
            norseFont = Resources.FindObjectsOfTypeAll<Font>().FirstOrDefault(fnt => fnt.name == "Norse");
            modSettingsBundle = AssetBundle.LoadFromStream(EmbeddedAsset.LoadEmbeddedAsset("Assets.Bundles.settings-ui"));
            modSettingsPanelCloner = modSettingsBundle.LoadAsset<GameObject>("Mod Settings");
            enableToggle = modSettingsBundle.LoadAsset<GameObject>("Toggle_Enable");
            uiTooltipPrefab = modSettingsBundle.LoadAsset<GameObject>("SettingsTooltip");
            keycodeNames = Enum.GetNames(typeof(KeyCode));
            modSettingsPanelCloner.SetActive(false);
        }

        private static void Apply()
        {
            if (File.Exists(ConfigurationHelper.Path))
            {
                Log.LogInfo("Applying values to config file...");
                FileIniDataParser parser = new FileIniDataParser();
                IniData configdata = parser.ReadFile(ConfigurationHelper.Path);
                foreach (KeyValuePair<string, List<GameObject>> settingSection in settingFamillySettings)
                {
                    foreach (GameObject settingEntry in settingSection.Value)
                    {
                        PropertyInfo propSection = Configuration.Current.GetType().GetProperty(settingSection.Key);
                        var settingFamilyProp = propSection.GetValue(Configuration.Current, null);
                        Type propType = settingFamilyProp.GetType();
                        if (settingEntry.name.Contains("Toggle_Enable"))
                        {
                            Toggle enableSectionTog = settingEntry.GetComponentInChildren<Toggle>();
                            PropertyInfo prop = propType.GetProperty("IsEnabled");
                            prop.SetValue(settingFamilyProp, enableSectionTog.isOn);
                            configdata[settingSection.Key]["enabled"] = enableSectionTog.isOn.ToString();
                        }
                        else
                        {
                            InputField inputEntry = settingEntry.GetComponentInChildren<InputField>();
                            Toggle enableSectionTog = settingEntry.GetComponentInChildren<Toggle>();
                            Dropdown inputDropdown = settingEntry.GetComponentInChildren<Dropdown>();
                            if (inputEntry != null)
                            {
                                string newVal = inputEntry.text;
                                if (newVal == "")
                                    continue;
                                else
                                {
                                    PropertyInfo prop = propType.GetProperty(settingEntry.name.Replace("(Clone)", ""));
                                    if (prop.PropertyType == typeof(float))
                                    {
                                        configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = newVal;
                                        continue;
                                    }

                                    if (prop.PropertyType == typeof(int))
                                    {
                                        configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = newVal;
                                        continue;
                                    }

                                    if (prop.PropertyType == typeof(bool))
                                    {
                                        configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = newVal;
                                        continue;
                                    }

                                    if (prop.PropertyType == typeof(KeyCode))
                                    {
                                        configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = newVal;
                                        continue;
                                    }

                                    settingFamillySettings[settingSection.Key][settingFamillySettings[settingSection.Key].IndexOf(settingEntry)] =
                                        CreateTextSettingEntry(settingEntry.name.Replace("(Clone)", ""),
                                        newVal, settingEntry.transform.parent,
                                        string.Join("\n", configdata[settingSection.Key].GetKeyData(settingEntry.name.Replace("(Clone)", "")).Comments));
                                }
                            }
                            else if (inputDropdown != null)
                            {
                                PropertyInfo prop = propType.GetProperty(settingEntry.name.Replace("(Clone)", ""));
                                string newVal = keycodeNames[inputDropdown.value];
                                if (newVal == ((KeyCode)prop.GetValue(settingFamilyProp, null)).ToString())
                                {
                                    continue;
                                }

                                if (prop.PropertyType == typeof(KeyCode))
                                {
                                    configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = newVal;
                                    continue;
                                }
                            }
                            else
                            {
                                PropertyInfo prop = propType.GetProperty(settingEntry.name.Replace("(Clone)", ""));
                                configdata[settingSection.Key][settingEntry.name.Replace("(Clone)", "")] = enableSectionTog.isOn.ToString();
                            }
                        }
                    }
                }

                parser.WriteFile(ConfigurationHelper.Path, configdata);
                Log.LogInfo("Values written to config file. Reloading it...");
                Configuration.Current = ConfigurationHelper.ReadFromFile(ConfigurationHelper.Path);
                Log.LogInfo("Config reloaded. Re-patching...");
                ValheimPlusPlugin.UnpatchSelf();
                ValheimPlusPlugin.PatchAll();
                Log.LogInfo("Re-patched. Done applying config.");
            }
        }

        private static void Show()
        {
            norseFont = Resources.FindObjectsOfTypeAll<Font>().FirstOrDefault(fnt => fnt.name == "Norse");
            settingFamillySettings = new Dictionary<string, List<GameObject>>();
            if (modSettingsPanelCloner == null)
            {
                Load();
            }

            if (modSettingsPanel == null)
            {
                modSettingsPanel = GameObject.Instantiate(modSettingsPanelCloner);
                modSettingsPanel.transform.SetParent(FejdStartup.instance.m_mainMenu.transform, false);
                modSettingsPanel.transform.localPosition = Vector3.zero;
                applyButton = modSettingsPanel.GetChildComponentByName<Button>("Apply");
                dropper = modSettingsPanel.GetComponentInChildren<Dropdown>();
                okButton = modSettingsPanel.GetChildComponentByName<Button>("OK");
                applyButton.onClick.AddListener(delegate
                {
                    int dropdownval = dropper.value;
                    dropper.value = 0;
                    Apply();
                    Show();
                    dropper.value = dropdownval;
                });
                okButton.onClick.AddListener(delegate
                {
                    Apply();
                    modSettingsPanel.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                });
                applyButton.gameObject.SetActive(false);
            }

            settingsContentPanel = modSettingsPanel.GetChildComponentByName<Transform>("SettingsContent").gameObject;
            settingsContentPanel.transform.parent.parent.gameObject.GetComponentInChildren<Scrollbar>().direction = Scrollbar.Direction.BottomToTop;
            dropper.options.Clear();
            FileIniDataParser parser = new FileIniDataParser();
            IniData configdata = parser.ReadFile(ConfigurationHelper.Path);
            foreach (var prop in typeof(Configuration).GetProperties())
            {
                string keyName = prop.Name;
                if (keyName == "Current" || keyName == "Settings" || keyName == "Time" || keyName == "Deconstruct")
                {
                    continue;
                }
                else
                {
                    settingFamillySettings.Add(keyName, new List<GameObject>());
                    var settingFamillyProp = Configuration.Current.GetType().GetProperty(prop.Name).GetValue(Configuration.Current, null);
                    GameObject enableToggleThis = CreateEnableToggle(keyName,
                                                                    settingFamillyProp.GetType().GetProperty("IsEnabled").GetValue(settingFamillyProp).ToString(),
                                                                    settingsContentPanel.transform,
                                                                    string.Join("\n", configdata[keyName].GetKeyData("enabled").Comments));
                    settingFamillySettings[keyName].Add(enableToggleThis);
                    var praeteriCommentarium = "";
                    foreach (var setting in prop.PropertyType.GetProperties())
                    {
                        if (setting.Name == "NeedsServerSync")
                            continue;

                        var keyDatumCommentate = configdata[keyName].GetKeyData(setting.Name);
                        var commentarium = "";
                        if (keyDatumCommentate != null)
                        {
                            commentarium = string.Join("\n", keyDatumCommentate.Comments);
                            praeteriCommentarium = commentarium;
                        }
                        else
                        {
                            commentarium = praeteriCommentarium;
                        }

                        if (settingFamillyProp.GetType().GetProperty(setting.Name).PropertyType == typeof(bool))
                        {
                            settingFamillySettings[keyName].Add(CreateBoolSettingEntry(setting.Name,
                                                                    settingFamillyProp.GetType().GetProperty(setting.Name).GetValue(settingFamillyProp, null).ToString(),
                                                                    settingsContentPanel.transform, commentarium));
                        }
                        else if (settingFamillyProp.GetType().GetProperty(setting.Name).PropertyType == typeof(KeyCode))
                        {
                            settingFamillySettings[keyName].Add(CreateKeyCodeSettingEntry(setting.Name,
                                                                    settingFamillyProp.GetType().GetProperty(setting.Name).GetValue(settingFamillyProp, null).ToString(),
                                                                    settingsContentPanel.transform, commentarium));
                        }
                        else
                        {
                            settingFamillySettings[keyName].Add(CreateTextSettingEntry(setting.Name,
                                                                    settingFamillyProp.GetType().GetProperty(setting.Name).GetValue(settingFamillyProp, null).ToString(),
                                                                    settingsContentPanel.transform, commentarium));
                        }
                    }

                    dropper.options.Add(new Dropdown.OptionData(keyName));
                }
            }

            availableSettings = dropper.options.Select(option => option.text).ToList();
            dropper.onValueChanged.AddListener(delegate
            {
                foreach (Transform ting in settingsContentPanel.transform) { ting.gameObject.SetActive(false); }
                foreach (GameObject newTing in settingFamillySettings[availableSettings[dropper.value]]) { newTing.SetActive(true); }
            });

            dropper.value = availableSettings.IndexOf("ValheimPlus");
            modSettingsPanel.SetActive(true);
        }
    }

}

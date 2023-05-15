using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations
{
    public class FirstPersonConfiguration : BaseConfig
    {
        [ConfigDescription("Hotkey to enable First Person.")]
        public ConfigModel<KeyCode> Hotkey { get; internal set; } = KeyCode.F10;
        [ConfigDescription("Default Field Of View to use.")]
        public ConfigModel<KeyCode> RaiseFOVHotkey { get; internal set; } = KeyCode.PageUp;
        [ConfigDescription("Hotkey to raise Field Of View.")]
        public ConfigModel<float> DefaultFOV { get; internal set; } = 65.0f;
        [ConfigDescription("Hotkey to lower Field Of View.")]
        public ConfigModel<KeyCode> LowerFOVHotkey { get; internal set; } = KeyCode.PageDown;
    }
}
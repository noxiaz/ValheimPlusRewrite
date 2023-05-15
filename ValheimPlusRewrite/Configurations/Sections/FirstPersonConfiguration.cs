using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations
{
    public class FirstPersonConfiguration : BaseConfig
    {
        [Description("Hotkey to enable First Person.")]
        public ConfigModel<KeyCode> Hotkey { get; internal set; } = KeyCode.F10;
        [Description("Default Field Of View to use.")]
        public ConfigModel<KeyCode> RaiseFOVHotkey { get; internal set; } = KeyCode.PageUp;
        [Description("Hotkey to raise Field Of View.")]
        public ConfigModel<float> DefaultFOV { get; internal set; } = 65.0f;
        [Description("Hotkey to lower Field Of View.")]
        public ConfigModel<KeyCode> LowerFOVHotkey { get; internal set; } = KeyCode.PageDown;
    }
}
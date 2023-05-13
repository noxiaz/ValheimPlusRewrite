using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations
{
    public class FirstPersonConfiguration : BaseConfig
    {
        public ConfigModel<KeyCode> Hotkey { get; internal set; } = KeyCode.F10;
        public ConfigModel<KeyCode> RaiseFOVHotkey { get; internal set; } = KeyCode.PageUp;
        public ConfigModel<float> DefaultFOV { get; internal set; } = 65.0f;
        public ConfigModel<KeyCode> LowerFOVHotkey { get; internal set; } = KeyCode.PageDown;
    }
}
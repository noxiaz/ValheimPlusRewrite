using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations
{
    public class FirstPersonConfiguration : BaseConfig
    {
        public KeyCode hotkey { get; internal set; } = KeyCode.F10;
        public KeyCode raiseFOVHotkey { get; internal set; } = KeyCode.PageUp;
        public float defaultFOV { get; internal set; } = 65.0f;
        public KeyCode lowerFOVHotkey { get; internal set; } = KeyCode.PageDown;
    }
}
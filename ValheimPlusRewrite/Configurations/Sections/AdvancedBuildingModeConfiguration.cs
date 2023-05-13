using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class AdvancedBuildingModeConfiguration : BaseConfig
    {
        public ConfigModel<KeyCode> EnterAdvancedBuildingMode { get; internal set; } = KeyCode.F1;
        public ConfigModel<KeyCode> ExitAdvancedBuildingMode { get; internal set; } = KeyCode.F3;

        public ConfigModel<KeyCode> CopyObjectRotation { get; internal set; } = KeyCode.Keypad7;
        public ConfigModel<KeyCode> PasteObjectRotation { get; internal set; } = KeyCode.Keypad8;

        public ConfigModel<KeyCode> IncreaseScrollSpeed { get; internal set; } = KeyCode.KeypadPlus;
        public ConfigModel<KeyCode> DecreaseScrollSpeed { get; internal set; } = KeyCode.KeypadMinus;
    }
}

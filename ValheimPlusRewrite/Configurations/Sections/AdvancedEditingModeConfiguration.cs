using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class AdvancedEditingModeConfiguration : BaseConfig
    {
        public ConfigModel<KeyCode> EnterAdvancedEditingMode { get; internal set; } = KeyCode.Keypad0;
        public ConfigModel<KeyCode> ResetAdvancedEditingMode { get; internal set; } = KeyCode.F7;
        public ConfigModel<KeyCode> AbortAndExitAdvancedEditingMode { get; internal set; } =  KeyCode.F8;
        public ConfigModel<KeyCode> ConfirmPlacementOfAdvancedEditingMode { get; internal set; } = KeyCode.KeypadEnter;
        public ConfigModel<KeyCode> CopyObjectRotation { get; internal set; } = KeyCode.Keypad7;
        public ConfigModel<KeyCode> PasteObjectRotation { get; internal set; } = KeyCode.Keypad8;
        public ConfigModel<KeyCode> IncreaseScrollSpeed { get; internal set; } = KeyCode.KeypadPlus;
        public ConfigModel<KeyCode> DecreaseScrollSpeed { get; internal set; } = KeyCode.KeypadMinus;
    }
}

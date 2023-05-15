using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class AdvancedBuildingModeConfiguration : BaseConfig
    {
        [Description("Enter the advanced building mode with this key when building.")]
        public ConfigModel<KeyCode> EnterAdvancedBuildingMode { get; internal set; } = KeyCode.F1;
        [Description("Exit the advanced building mode with this key when building.")]
        public ConfigModel<KeyCode> ExitAdvancedBuildingMode { get; internal set; } = KeyCode.F3;
        [Description("Copy the object rotation of the currently selected object in ABM")]
        public ConfigModel<KeyCode> CopyObjectRotation { get; internal set; } = KeyCode.Keypad7;
        [Description("Apply the copied object rotation to the currently selected object in ABM")]
        public ConfigModel<KeyCode> PasteObjectRotation { get; internal set; } = KeyCode.Keypad8;
        [Description("Increases the amount an object rotates and moves. Holding Shift will increase in increments of 10 instead of 1.")]
        public ConfigModel<KeyCode> IncreaseScrollSpeed { get; internal set; } = KeyCode.KeypadPlus;
        [Description("Decreases the amount an object rotates and moves. Holding Shift will decrease in increments of 10 instead of 1.")]
        public ConfigModel<KeyCode> DecreaseScrollSpeed { get; internal set; } = KeyCode.KeypadMinus;
    }
}

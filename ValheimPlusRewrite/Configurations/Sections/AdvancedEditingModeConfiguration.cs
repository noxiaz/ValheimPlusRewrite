﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class AdvancedEditingModeConfiguration : BaseConfig
    {
        [ConfigDescription("Enter the advanced editing mode with this key")]
        public ConfigModel<KeyCode> EnterAdvancedEditingMode { get; internal set; } = KeyCode.Keypad0;
        [ConfigDescription("Reset the object to its original position and rotation")]
        public ConfigModel<KeyCode> ResetAdvancedEditingMode { get; internal set; } = KeyCode.F7;
        [ConfigDescription("Exit the advanced editing mode with this key and reset the object")]
        public ConfigModel<KeyCode> AbortAndExitAdvancedEditingMode { get; internal set; } = KeyCode.F8;
        [ConfigDescription("Confirm the placement of the object and place it")]
        public ConfigModel<KeyCode> ConfirmPlacementOfAdvancedEditingMode { get; internal set; } = KeyCode.KeypadEnter;
        [ConfigDescription("Copy the object rotation of the currently selected object in AEM")]
        public ConfigModel<KeyCode> CopyObjectRotation { get; internal set; } = KeyCode.Keypad7;
        [ConfigDescription("Apply the copied object rotation to the currently selected object in AEM")]
        public ConfigModel<KeyCode> PasteObjectRotation { get; internal set; } = KeyCode.Keypad8;
        public ConfigModel<KeyCode> IncreaseScrollSpeed { get; internal set; } = KeyCode.KeypadPlus;
        [ConfigDescription("Decreases the amount an object rotates and moves. Holding Shift will decrease in increments of 10 instead of 1.")]
        public ConfigModel<KeyCode> DecreaseScrollSpeed { get; internal set; } = KeyCode.KeypadMinus;
    }
}

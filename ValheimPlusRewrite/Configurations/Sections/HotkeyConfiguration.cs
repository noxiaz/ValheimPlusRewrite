﻿using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class HotkeyConfiguration : BaseConfig
    {
        [Description("Roll forwards on hot key pressed.")]
        public ConfigModel<KeyCode> RollForwards { get; internal set; } = KeyCode.F9;
        [Description("Roll backwards on hot key pressed.")]
        public ConfigModel<KeyCode> RollBackwards { get; internal set; } = KeyCode.F10;
    }
}

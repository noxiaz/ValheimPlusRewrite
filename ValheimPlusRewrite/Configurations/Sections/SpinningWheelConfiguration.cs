﻿using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class SpinningWheelConfiguration : ServerSyncConfig
    {
        [Description("Maximum amount of flax in a spinning wheel.")]
        public ConfigModel<int> MaximumFlax { get; internal set; } = 50;
        [Description("The time it takes for the spinning wheel to produce linen thread.")]
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 30;
        [Description("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = true;
        [Description("The Spinning Wheel will pull flax from nearby chests to be automatically added to it when its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = true;
        [Description("This option prevents the Spinning Wheel to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [Description("The range of the chest detection for the auto deposit and auto fuel features")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

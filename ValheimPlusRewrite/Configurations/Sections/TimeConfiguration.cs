﻿using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TimeConfiguration : ServerSyncConfig
    {
        [Description("NOT IMPLEMENTED - ITS NOT DONE")]
        public ConfigModel<float> TotalDayTimeInSeconds { get; internal set; } = 1200;
        [Description("NOT IMPLEMENTED - ITS NOT DONE")]
        public ConfigModel<float> NightTimeSpeedMultiplier { get; internal set; } = 0;
    }
}

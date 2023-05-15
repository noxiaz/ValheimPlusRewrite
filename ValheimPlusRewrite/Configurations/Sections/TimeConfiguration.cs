using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TimeConfiguration : ServerSyncConfig
    {
        [ConfigDescription("NOT IMPLEMENTED - ITS NOT DONE")]
        public ConfigModel<float> TotalDayTimeInSeconds { get; internal set; } = 1200;
        [ConfigDescription("NOT IMPLEMENTED - ITS NOT DONE")]
        public ConfigModel<float> NightTimeSpeedMultiplier { get; internal set; } = 0;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TimeConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> TotalDayTimeInSeconds { get; internal set; } = 1200;
        public ConfigModel<float> NightTimeSpeedMultiplier { get; internal set; } = 0;
    }
}

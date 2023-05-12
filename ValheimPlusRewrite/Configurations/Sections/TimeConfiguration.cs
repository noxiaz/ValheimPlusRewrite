using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TimeConfiguration : ServerSyncConfig
    {
        public float totalDayTimeInSeconds { get; internal set; } = 1200;
        public float nightTimeSpeedMultiplier { get; internal set; } = 0;
    }
}

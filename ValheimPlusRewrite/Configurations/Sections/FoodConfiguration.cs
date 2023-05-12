using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FoodConfiguration : ServerSyncConfig
    {
        public float foodDurationMultiplier { get; internal set; } = 0;
        public bool disableFoodDegradation { get; internal set; } = false;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FoodConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> FoodDurationMultiplier { get; internal set; } = 0;
        public ConfigModel<bool> DisableFoodDegradation { get; internal set; } = false;
    }
}

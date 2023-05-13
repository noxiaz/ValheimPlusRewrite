using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PlayerProjectileConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> PlayerMinChargeVelocityMultiplier { get; internal set; } = 0;
        public ConfigModel<float> PlayerMaxChargeVelocityMultiplier { get; internal set; } = 0;
        public ConfigModel<float> PlayerMinChargeAccuracyMultiplier { get; internal set; } = 0;
        public ConfigModel<float> PlayerMaxChargeAccuracyMultiplier { get; internal set; } = 0;
        public ConfigModel<bool> EnableScaleWithSkillLevel { get; internal set; } = false;
    }
}
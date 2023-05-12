using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PlayerProjectileConfiguration : ServerSyncConfig
    {
        public float playerMinChargeVelocityMultiplier { get; internal set; } = 0;
        public float playerMaxChargeVelocityMultiplier { get; internal set; } = 0;

        public float playerMinChargeAccuracyMultiplier { get; internal set; } = 0;
        public float playerMaxChargeAccuracyMultiplier { get; internal set; } = 0;

        public bool enableScaleWithSkillLevel { get; internal set; } = false;
    }
}
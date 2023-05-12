using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class MonsterProjectileConfiguration : ServerSyncConfig
    {
        public float monsterMaxChargeVelocityMultiplier { get; internal set; } = 0;

        public float monsterMaxChargeAccuracyMultiplier { get; internal set; } = 0;
    }
}
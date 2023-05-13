using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class MonsterProjectileConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> MonsterMaxChargeVelocityMultiplier { get; internal set; } = 0;
        public ConfigModel<float> MonsterMaxChargeAccuracyMultiplier { get; internal set; } = 0;
    }
}
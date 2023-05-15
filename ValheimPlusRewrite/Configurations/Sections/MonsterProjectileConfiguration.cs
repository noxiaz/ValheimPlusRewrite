using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class MonsterProjectileConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Value of 10 would increase the projectile velocity from 50 to 55.")]
        public ConfigModel<float> MonsterMaxChargeVelocityMultiplier { get; internal set; } = 0;
        [ConfigDescription("Value of (+)10 increase in accuracy will change the variance of projectile 1 degree to 0.9 degree at the point of projectile release.")]
        public ConfigModel<float> MonsterMaxChargeAccuracyMultiplier { get; internal set; } = 0;
    }
}
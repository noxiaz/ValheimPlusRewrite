using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PlayerProjectileConfiguration : ServerSyncConfig
    {
        [Description("Value of 50 would increase the minimum charge velocity from 2 to 3.")]
        public ConfigModel<float> PlayerMinChargeVelocityMultiplier { get; internal set; } = 0;
        [Description("Value of 50 would increase the maximum charge velocity (of Finwood bow) from 50 to 75")]
        public ConfigModel<float> PlayerMaxChargeVelocityMultiplier { get; internal set; } = 0;
        [Description("Value of (+)50 increase in accuracy will change the variance of arrows 20 degree to 10 degree at the point of minimum charge release.")]
        public ConfigModel<float> PlayerMinChargeAccuracyMultiplier { get; internal set; } = 0;
        [Description("Value of (+)50 increase in accuracy will change the variance of arrows 1 degree to 0.5 degree at the point of maximum charge release.")]
        public ConfigModel<float> PlayerMaxChargeAccuracyMultiplier { get; internal set; } = 0;
        [Description("Enabling this option will linearly scale by skill level from the base values of the weapon to the modified values (according to multipliers above).")]
        public ConfigModel<bool> EnableScaleWithSkillLevel { get; internal set; } = false;
    }
}
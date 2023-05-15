using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StaminaConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Changes the amount of stamina cost of using the dodge roll by %")]
        public ConfigModel<float> DodgeStaminaUsage { get; internal set; } = 0;
        [ConfigDescription("Changes the stamina drain of being overweight by %")]
        public ConfigModel<float> EncumberedStaminaDrain { get; internal set; } = 0;
        [ConfigDescription("Changes the stamina cost of jumping by %")]
        public ConfigModel<float> JumpStaminaDrain { get; internal set; } = 0;
        [ConfigDescription("Changes the stamina cost of running by %")]
        public ConfigModel<float> RunStaminaDrain { get; internal set; } = 0;
        [ConfigDescription("Changes the stamina drain by sneaking by %")]
        public ConfigModel<float> SneakStaminaDrain { get; internal set; } = 0;
        [ConfigDescription("Changes the total amount of stamina recovered per second by %")]
        public ConfigModel<float> StaminaRegen { get; internal set; } = 0;
        [ConfigDescription("Changes the delay until stamina regeneration sets in by %")]
        public ConfigModel<float> StaminaRegenDelay { get; internal set; } = 0;
        [ConfigDescription("Changes the stamina drain of swimming by %")]
        public ConfigModel<float> SwimStaminaDrain { get; internal set; } = 0;
    }
}

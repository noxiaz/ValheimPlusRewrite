using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StaminaConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> DodgeStaminaUsage { get; internal set; } = 0;
        public ConfigModel<float> EncumberedStaminaDrain { get; internal set; } = 0;
        public ConfigModel<float> JumpStaminaDrain { get; internal set; } = 0;
        public ConfigModel<float> RunStaminaDrain { get; internal set; } = 0;
        public ConfigModel<float> SneakStaminaDrain { get; internal set; } = 0;
        public ConfigModel<float> StaminaRegen { get; internal set; } = 0;
        public ConfigModel<float> StaminaRegenDelay { get; internal set; } = 0;
        public ConfigModel<float> SwimStaminaDrain { get; internal set; } = 0;
    }
}

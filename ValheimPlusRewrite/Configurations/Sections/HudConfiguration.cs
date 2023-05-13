using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class HudConfiguration : BaseConfig
    {
        public ConfigModel<bool> ShowRequiredItems { get; internal set; } = false;
        public ConfigModel<bool> ExperienceGainedNotifications { get; internal set; } = false;
        public ConfigModel<bool> RemoveDamageFlash { get; internal set; } = false;
        public ConfigModel<int> DisplayBowAmmoCounts { get; internal set; } = 0;
    }
}

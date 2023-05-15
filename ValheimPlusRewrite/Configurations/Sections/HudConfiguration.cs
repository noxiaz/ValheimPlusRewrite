using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class HudConfiguration : BaseConfig
    {
        [Description("Shows the required amount of items AND the amount of items in your inventory in build mode and while crafting. - This is enabled when the CraftFromChest section is enabled.")]
        public ConfigModel<bool> ShowRequiredItems { get; internal set; } = false;
        [Description("Shows small notifications about all skill experienced gained in the top left corner.")]
        public ConfigModel<bool> ExperienceGainedNotifications { get; internal set; } = false;
        [Description("Set to true to remove the red screen flash overlay when the player takes damage.")]
        public ConfigModel<bool> RemoveDamageFlash { get; internal set; } = false;
        [Description("If bow is in hotbar, display current ammo & total ammo under hotbar icon - never (0), when equipped (1), or always (2).")]
        public ConfigModel<int> DisplayBowAmmoCounts { get; internal set; } = 0;
    }
}

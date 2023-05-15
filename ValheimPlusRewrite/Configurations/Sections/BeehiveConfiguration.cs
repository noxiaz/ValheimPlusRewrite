using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BeehiveConfiguration : ServerSyncConfig
    {
        [Description("Configure the speed at which the bees produce honey in seconds, 1200 seconds are 24 ingame hours.")]
        public ConfigModel<float> HoneyProductionSpeed { get; internal set; } = 1200;
        [Description("Configure the maximum amount of honey in beehives.")]
        public ConfigModel<int> MaximumHoneyPerBeehive { get; internal set; } = 4;
        [Description("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [Description("The range of the chest detection for the auto deposit feature. - Maximum is 50")]
        public ConfigModel<float> AutoDepositRange { get; internal set; } = 10;
        [Description("Display the minutes and seconds until the beehive produces honey on crosshair hover.")]
        public ConfigModel<bool> ShowDuration { get; internal set; } = false;
    }

}

using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class SmelterConfiguration : ServerSyncConfig
    {
        [Description("Maximum amount of ore in a Smelter.")]
        public ConfigModel<int> MaximumOre { get; internal set; } = 10;
        [Description("Maximum amount of coal in a Smelter.")]
        public ConfigModel<int> MaximumCoal { get; internal set; } = 20;
        [Description("The total amount of coal used to produce a single smelted ingot.")]
        public ConfigModel<int> CoalUsedPerProduct { get; internal set; } = 2;
        [Description("The time it takes for the Smelter to produce a single ingot in seconds.")]
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 30;
        [Description("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [Description("The Smelter will pull coal and raw materials from nearby chests to be automatically added to it when its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [Description("This option prevents the Smelter to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [Description("The range of the chest detection for the auto deposit and auto fuel features. - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }

}

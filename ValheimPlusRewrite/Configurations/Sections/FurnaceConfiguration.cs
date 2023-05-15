using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FurnaceConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Maximum amount of ore in a Furnace.")]
        public ConfigModel<int> MaximumOre { get; internal set; } = 10;
        [ConfigDescription("Maximum amount of coal in a Furnace.")]
        public ConfigModel<int> MaximumCoal { get; internal set; } = 20;
        [ConfigDescription("The total amount of coal used to produce a single smelted ingot.")]
        public ConfigModel<int> CoalUsedPerProduct { get; internal set; } = 2;
        [ConfigDescription("The time it takes for the Furnace to produce a single ingot in seconds.")]
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 30;
        [ConfigDescription("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [ConfigDescription("The Furnace will pull coal and raw materials from nearby chests to be automatically added to it when its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [ConfigDescription("This option prevents the Furnace to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [ConfigDescription("The range of the chest detection for the auto deposit and auto fuel features. - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
        [ConfigDescription("This option allows all ores inside the Furnace.")]
        public ConfigModel<bool> AllowAllOres { get; internal set; } = false;
    }

}

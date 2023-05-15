using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FermenterConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Configure the time that the fermenter takes to produce its product, 2400 seconds are 48 ingame hours.")]
        public ConfigModel<float> FermenterDuration { get; internal set; } = 2400;
        [ConfigDescription("Configure the total amount of produced items from a fermenter.")]
        public ConfigModel<int> FermenterItemsProduced { get; internal set; } = 4;
        [ConfigDescription("Display the minutes and seconds until the fermenter is done on crosshair hover.")]
        public ConfigModel<bool> ShowDuration { get; internal set; } = false;
        [ConfigDescription("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [ConfigDescription("Automatically pull meads from nearby chests to be placed inside the Fermenter as soon as its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [ConfigDescription("This option prevents the fermenter to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = false;
        [ConfigDescription("The range of the chest detection for the auto deposit and auto fuel features - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }

}

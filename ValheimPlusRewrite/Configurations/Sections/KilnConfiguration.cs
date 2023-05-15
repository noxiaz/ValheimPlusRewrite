using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class KilnConfiguration : ServerSyncConfig
    {
        [Description("Maximum amount of wood in a Kiln.")]
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 15;
        [Description("Change false to true to disable Fine Wood processing.")]
        public ConfigModel<int> MaximumWood { get; internal set; } = 25;
        [Description("Change false to true to disabled Round Log processing.")]
        public ConfigModel<bool> DontProcessFineWood { get; internal set; } = false;
        [Description("The time it takes for the Kiln to produce a single piece of coal in seconds.")]
        public ConfigModel<bool> DontProcessRoundLog { get; internal set; } = false;
        [Description("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [Description("The Kiln will pull wood from nearby chests to be automatically added to it when its empty. - This option respects the dontProcessFineWood and dontProcessRoundLog settings.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [Description("Stops autoFuel (looking for fuel) when there is at leasts this quantity of Coal in nearby chests. (ignored if set to 0)")]
        public ConfigModel<int> StopAutoFuelThreshold { get; internal set; } = 0;
        [Description("This option prevents the Kiln to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [Description("The range of the chest detection for the auto deposit and fuel features. - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }

}

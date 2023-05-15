using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WindmillConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Maximum amount of barley in a windmill.")]
        public ConfigModel<int> MaximumBarley { get; internal set; } = 50;
        [ConfigDescription("The time it takes for the windmill to produce a single ingot in seconds.")]
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 10;
        [ConfigDescription("Ignore wind intensity so it always takes the production speed value to process one barley.")]
        public ConfigModel<bool> IgnoreWindIntensity { get; internal set; } = false;
        [ConfigDescription("Instead of dropping the items, they will be placed inside the nearest nearby chests.")]
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        [ConfigDescription("The Windmill will pull barley from nearby chests to be automatically added to it when its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [ConfigDescription("This option prevents the Windmill to pull items from warded areas if it isn't placed inside of it. - For convenience, we recommend this to be set to true.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [ConfigDescription("The range of the chest detection for the auto deposit and auto fuel features. - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

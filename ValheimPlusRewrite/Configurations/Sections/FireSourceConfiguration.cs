using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FireSourceConfiguration : ServerSyncConfig
    {
        [ConfigDescription("If set to true, torch-type fire sources will stay at max fuel level once filled. - Applies to: wood torches, iron torches, green torches, sconces and brazier.")]
        public ConfigModel<bool> Torches { get; internal set; } = false;
        [ConfigDescription("If set to true, non torch-type fire sources will stay at max fuel level once filled.")]
        public ConfigModel<bool> Fires { get; internal set; } = false;
        [ConfigDescription("Automatically pull wood from nearby chests to be placed inside the Fire as soon as its empty.")]
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        [ConfigDescription("This option prevents the Fire to pull items from warded areas if it isn't placed inside of it.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        [ConfigDescription("The range of the chest detection for the auto fuel features. - Maximum is 50")]
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

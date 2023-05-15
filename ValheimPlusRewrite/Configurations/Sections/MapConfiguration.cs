using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class MapConfiguration : ServerSyncConfig
    {
        [ConfigDescription("With this enabled you will receive the same exploration progression as other players on the server. - This will also enable the option for the server to sync everyones exploration progression on connecting to the server.")]
        public ConfigModel<bool> ShareMapProgression { get; internal set; } = false;
        [ConfigDescription("The radius of the map that you explore when moving.")]
        public ConfigModel<float> ExploreRadius { get; internal set; } = 50;
        [ConfigDescription("Prevents you and other people on the server to turn off their map sharing option.")]
        public ConfigModel<bool> PreventPlayerFromTurningOffPublicPosition { get; internal set; } = false;
        [ConfigDescription("This option automatically shares created pins with everyone playing on the server.")]
        public ConfigModel<bool> ShareAllPins { get; internal set; } = false;
        [ConfigDescription("Display carts and boats on the map")]
        public ConfigModel<bool> DisplayCartsAndBoats { get; internal set; } = false;
        /*
         * relics from the old vplus map pin UI
        public bool useImprovedPinEditorUI { get; internal set; } = false;
        public bool shareablePins { get; internal set; } = false;  
        */
    }
}

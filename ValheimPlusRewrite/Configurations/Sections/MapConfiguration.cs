using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class MapConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> ShareMapProgression { get; internal set; } = false;
        public ConfigModel<float> ExploreRadius { get; internal set; } = 50;
        public ConfigModel<bool> PreventPlayerFromTurningOffPublicPosition { get; internal set; } = false;
        public ConfigModel<bool> ShareAllPins { get; internal set; } = false;
        public ConfigModel<bool> DisplayCartsAndBoats { get; internal set; } = false;
        /*
         * relics from the old vplus map pin UI
        public bool useImprovedPinEditorUI { get; internal set; } = false;
        public bool shareablePins { get; internal set; } = false;  
        */
    }
}

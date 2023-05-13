using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BuildingConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> NoInvalidPlacementRestriction { get; internal set; } = false;
        public ConfigModel<bool> NoMysticalForcesPreventPlacementRestriction { get; internal set; } = false;
        public ConfigModel<bool> NoWeatherDamage { get; internal set; } = false;
        public ConfigModel<float> MaximumPlacementDistance { get; internal set; } = 8;
        public ConfigModel<float> PieceComfortRadius { get; internal set; } = 10;
        public ConfigModel<bool> AlwaysDropResources { get; internal set; } = false;
        public ConfigModel<bool> AlwaysDropExcludedResources { get; internal set; } = false;
        public ConfigModel<bool> EnableAreaRepair { get; internal set; } = false;
        public ConfigModel<float> AreaRepairRadius { get; internal set; } = 7.5f;
    }
}

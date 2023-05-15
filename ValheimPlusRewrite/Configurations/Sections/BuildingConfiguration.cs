using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BuildingConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Remove some of the Invalid placement messages, most notably provides the ability to place objects into other objects")]
        public ConfigModel<bool> NoInvalidPlacementRestriction { get; internal set; } = false;
        [ConfigDescription("Removes the \"Mystical forces\" building prevention and allows destruction of build objects in those areas with the hammer.")]
        public ConfigModel<bool> NoMysticalForcesPreventPlacementRestriction { get; internal set; } = false;
        [ConfigDescription("Removes the weather damage from rain and water erosion.")]
        public ConfigModel<bool> NoWeatherDamage { get; internal set; } = false;
        [ConfigDescription("The maximum range in meters that you can place build objects at inside the hammer build mode.")]
        public ConfigModel<float> MaximumPlacementDistance { get; internal set; } = 8;
        [ConfigDescription("The radius, in meters, in which a piece must be to contribute to the comfort level.")]
        public ConfigModel<float> PieceComfortRadius { get; internal set; } = 10;
        [ConfigDescription("When destroying a building piece, setting this to true will ensure it always drops full resources.")]
        public ConfigModel<bool> AlwaysDropResources { get; internal set; } = false;
        [ConfigDescription("When destroying a building piece, setting this to true will ensure it always drops pieces that the devs have marked as \"do not drop\".")]
        public ConfigModel<bool> AlwaysDropExcludedResources { get; internal set; } = false;
        [ConfigDescription("Setting this to true will cause repairing with the hammer to repair in a radius instead of a single piece.")]
        public ConfigModel<bool> EnableAreaRepair { get; internal set; } = false;
        [ConfigDescription("Sets the area repair radius of enableAreaRepair. A value of 7.5 would mean your repair radius is 7.5 meters.")]
        [ConfigDescription("Requires enableAreaRepair=true")]
        public ConfigModel<float> AreaRepairRadius { get; internal set; } = 7.5f;
    }
}

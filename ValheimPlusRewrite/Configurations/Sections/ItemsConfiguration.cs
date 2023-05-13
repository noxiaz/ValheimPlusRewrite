using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ItemsConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> NoTeleportPrevention { get; internal set; } = false;
        public ConfigModel<float> BaseItemWeightReduction { get; internal set; } = 0;
        public ConfigModel<float> ItemStackMultiplier { get; internal set; } = 1;
        public ConfigModel<float> DroppedItemOnGroundDurationInSeconds { get; internal set; } = 3600;
        public ConfigModel<bool> ItemsFloatInWater { get; internal set; } = false;
    }
}

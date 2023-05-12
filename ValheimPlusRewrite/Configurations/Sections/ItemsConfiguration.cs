using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ItemsConfiguration : ServerSyncConfig
    {
        public bool noTeleportPrevention { get; internal set; } = false;
        public float baseItemWeightReduction { get; internal set; } = 0;
        public float itemStackMultiplier { get; internal set; } = 1;
        public float droppedItemOnGroundDurationInSeconds { get; internal set; } = 3600;
        public bool itemsFloatInWater { get; internal set; } = false;
    }
}

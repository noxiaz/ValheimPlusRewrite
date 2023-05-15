using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ItemsConfiguration : ServerSyncConfig
    {
        [Description("Enables you to teleport with ores and other usually teleport restricted objects.")]
        public ConfigModel<bool> NoTeleportPrevention { get; internal set; } = false;
        [Description("Increase or reduce item weight by a modifier in percent. - The value -50 will reduce item weight of every object by 50%, 50 will increase the weight of every item by 50%.")]
        public ConfigModel<float> BaseItemWeightReduction { get; internal set; } = 0;
        [Description("Increase or reduce the size of all maximum item stacks by a modifier in percent. - The value 50 would set a usual item stack of 100 to be 150. - The value -50 would set a usual item stack of 100 to be 50.")]
        public ConfigModel<float> ItemStackMultiplier { get; internal set; } = 1;
        [Description("Set duration that dropped items stay on the ground before they are despawning.")]
        public ConfigModel<float> DroppedItemOnGroundDurationInSeconds { get; internal set; } = 3600;
        [Description("Items dropped always float in water.")]
        public ConfigModel<bool> ItemsFloatInWater { get; internal set; } = false;
    }
}

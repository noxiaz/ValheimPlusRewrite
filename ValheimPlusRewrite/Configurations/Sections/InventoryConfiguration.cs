using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class InventoryConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> InventoryFillTopToBottom { get; internal set; } = false;
        public ConfigModel<bool> MergeWithExistingStacks { get; internal set; } = false;
        public ConfigModel<int> PlayerInventoryRows { get; internal set; } = 4;
        public ConfigModel<int> WoodChestColumns { get; internal set; } = 5;
        public ConfigModel<int> WoodChestRows { get; internal set; } = 2;
        public ConfigModel<int> PersonalChestColumns { get; internal set; } = 3;
        public ConfigModel<int> PersonalChestRows { get; internal set; } = 2;
        public ConfigModel<int> IronChestColumns { get; internal set; } = 6;
        public ConfigModel<int> IronChestRows { get; internal set; } = 4;
        public ConfigModel<int> BlackmetalChestColumns { get; internal set; } = 8;
        public ConfigModel<int> BlackmetalChestRows { get; internal set; } = 4;
        public ConfigModel<int> CartInventoryColumns { get; internal set; } = 8;
        public ConfigModel<int> CartInventoryRows { get; internal set; } = 3;
        public ConfigModel<int> KarveInventoryColumns { get; internal set; } = 2;
        public ConfigModel<int> KarveInventoryRows { get; internal set; } = 2;
        public ConfigModel<int> LongboatInventoryColumns { get; internal set; } = 8;
        public ConfigModel<int> LongboatInventoryRows { get; internal set; } = 3;
    }
}

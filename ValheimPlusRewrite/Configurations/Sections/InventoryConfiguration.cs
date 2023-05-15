using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class InventoryConfiguration : ServerSyncConfig
    {
        [Description("Player inventory number of rows (inventory is resized up to 6 rows, higher values will add a scrollbar).  min 4, max 20")]
        public ConfigModel<int> PlayerInventoryRows { get; internal set; } = 4;
        [Description("Wood chest number of columns (3 min, 8 max)")]
        public ConfigModel<int> WoodChestColumns { get; internal set; } = 5;
        [Description("Wood chest number of rows (more than 4 rows will add a scrollbar). (min 2, 10 max)")]
        public ConfigModel<int> WoodChestRows { get; internal set; } = 2;
        [Description("Personal chest number of columns. ( 3 min, 8 max)")]
        public ConfigModel<int> PersonalChestColumns { get; internal set; } = 3;
        [Description("Personal chest number of rows. ( 2 min, 20 max)")]
        public ConfigModel<int> PersonalChestRows { get; internal set; } = 2;
        [Description("Iron chest number of columns. (min 3, max 8)")]
        public ConfigModel<int> IronChestColumns { get; internal set; } = 6;
        [Description("Iron chest number of rows (more than 4 rows will add a scrollbar) (min 3, max 20)")]
        public ConfigModel<int> IronChestRows { get; internal set; } = 4;
        [Description("Blackmetal chests already have 8 columns by default but now you can lower it. (min 3, max 8)")]
        public ConfigModel<int> BlackmetalChestColumns { get; internal set; } = 8;
        [Description("Blackmetal number of rows (more than 4 rows will add a scrollbar). (min 3, max 20)")]
        public ConfigModel<int> BlackmetalChestRows { get; internal set; } = 4;
        [Description("Cart (Wagon) inventory number of columns. (min 6, max 8)")]
        public ConfigModel<int> CartInventoryColumns { get; internal set; } = 8;
        [Description("Cart (Wagon) inventory number of rows (more than 4 rows will add a scrollbar). (min 3, max 30)")]
        public ConfigModel<int> CartInventoryRows { get; internal set; } = 3;
        [Description("Karve (small boat) inventory number of columns. (min 2, max 8)")]
        public ConfigModel<int> KarveInventoryColumns { get; internal set; } = 2;
        [Description("Karve (small boat) inventory number of rows (more than 4 rows will add a scrollbar). (min 2, max 30)")]
        public ConfigModel<int> KarveInventoryRows { get; internal set; } = 2;
        [Description("Longboat (large boat) inventory number of columns. (min 6, max 8)")]
        public ConfigModel<int> LongboatInventoryColumns { get; internal set; } = 8;
        [Description("Longboat (large boat) inventory number of rows (more than 4 rows will add a scrollbar). (min 3, max 30)")]
        public ConfigModel<int> LongboatInventoryRows { get; internal set; } = 3;
        [Description("By default tools and weapons go into inventories top to bottom and other materials bottom to top. - Set to true to make all items go into the inventory top to bottom.")]
        public ConfigModel<bool> InventoryFillTopToBottom { get; internal set; } = false;
        [Description("By default items go to their original position when picking up your tombstone. - Set to true to make all stacks try to merge with an existing stack first.")]
        public ConfigModel<bool> MergeWithExistingStacks { get; internal set; } = false;
    }
}

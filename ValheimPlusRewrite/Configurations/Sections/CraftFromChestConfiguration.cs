using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class CraftFromChestConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Range { get; internal set; } = 20;
        public ConfigModel<bool> DisableCookingStation { get; internal set; } = false;
        public ConfigModel<bool> CheckFromWorkbench { get; internal set; } = true;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = false;
        public ConfigModel<int> LookupInterval { get; internal set; } = 3;
        public ConfigModel<bool> AllowCraftingFromCarts { get; internal set; } = false;
        public ConfigModel<bool> AllowCraftingFromShips { get; internal set; } = false;
    }
}

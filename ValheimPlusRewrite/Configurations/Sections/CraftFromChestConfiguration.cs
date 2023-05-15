using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class CraftFromChestConfiguration : ServerSyncConfig
    {
        [Description("Change false to true to disable this feature when using a Cooking Station.")]
        public ConfigModel<float> Range { get; internal set; } = 20;
        [Description("If in a workbench area, uses it as reference point when scanning for chests.")]
        public ConfigModel<bool> DisableCookingStation { get; internal set; } = false;
        [Description("This option prevents crafting to pull items from warded areas if the player doesnt have access to it.")]
        public ConfigModel<bool> CheckFromWorkbench { get; internal set; } = true;
        [Description("The range of the chest detection in meters.")]
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = false;
        [Description("The interval in seconds that the feature scans your nearby chests.")]
        public ConfigModel<int> LookupInterval { get; internal set; } = 3;
        [Description("Allows the system to use and see contents of carts for crafting. Might also allow use of other modded containers or vehicles not accessible otherwise.")]
        public ConfigModel<bool> AllowCraftingFromCarts { get; internal set; } = false;
        [Description("Allows the system to use and see contents of ships for crafting. Might also allow use of other modded containers or vehicles not accessible otherwise.")]
        public ConfigModel<bool> AllowCraftingFromShips { get; internal set; } = false;
    }
}

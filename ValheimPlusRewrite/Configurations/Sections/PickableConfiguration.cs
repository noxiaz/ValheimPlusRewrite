using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    [Description("Each value below (in percent) will modify the yield when \"picking\" items (default key E) such as berries and flowers. - A value of 100 will double drops, 200 will triple and so on.")]
    public class PickableConfiguration : ServerSyncConfig
    {
        [Description("All berries, all mushrooms, onions and carrots")]
        public ConfigModel<float> Edibles { get; internal set; } = 0;
        [Description("Barley, Flax, Dandelion, Thistle, Carrot Seeds, Turnip Seeds, Turnip, Onion Seeds")]
        public ConfigModel<float> FlowersAndIngredients { get; internal set; } = 0;
        [Description("Bone Fragments, Flint, Stone, Wood (branches on the ground)")]
        public ConfigModel<float> Materials { get; internal set; } = 0;
        [Description("Amber, Amber Pearl, Coins, Ruby")]
        public ConfigModel<float> Valuables { get; internal set; } = 0;
        [Description("Surtling Core only")]
        public ConfigModel<float> SurtlingCores { get; internal set; } = 0;
    }
}

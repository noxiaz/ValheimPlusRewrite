using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    [ConfigDescription("Each value below (in percent) will modify the yield when \"picking\" items (default key E) such as berries and flowers. - A value of 100 will double drops, 200 will triple and so on.")]
    public class PickableConfiguration : ServerSyncConfig
    {
        [ConfigDescription("All berries, all mushrooms, onions and carrots")]
        public ConfigModel<float> Edibles { get; internal set; } = 0;
        [ConfigDescription("Barley, Flax, Dandelion, Thistle, Carrot Seeds, Turnip Seeds, Turnip, Onion Seeds")]
        public ConfigModel<float> FlowersAndIngredients { get; internal set; } = 0;
        [ConfigDescription("Bone Fragments, Flint, Stone, Wood (branches on the ground)")]
        public ConfigModel<float> Materials { get; internal set; } = 0;
        [ConfigDescription("Amber, Amber Pearl, Coins, Ruby")]
        public ConfigModel<float> Valuables { get; internal set; } = 0;
        [ConfigDescription("Surtling Core only")]
        public ConfigModel<float> SurtlingCores { get; internal set; } = 0;
    }
}

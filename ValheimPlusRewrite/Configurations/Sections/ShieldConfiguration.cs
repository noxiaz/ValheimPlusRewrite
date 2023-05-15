using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ShieldConfiguration : ServerSyncConfig
    {
        [Description("Increase or decrease the block value on all shields in %. -50 would be 50% less block rating, 50 would be 50% more block rating.")]
        public ConfigModel<float> BlockRating { get; internal set; } = 0;
    }
}

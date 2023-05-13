using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ShieldConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> BlockRating { get; internal set; } = 0;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WagonConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> WagonExtraMassFromItems { get; internal set; } = 0;
        public ConfigModel<float> WagonBaseMass { get; internal set; } = 20;
    }
}

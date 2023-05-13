using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ArmorConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Helmets { get; internal set; } = 0;
        public ConfigModel<float> Chests { get; internal set; } = 0;
        public ConfigModel<float> Legs { get; internal set; } = 0;
        public ConfigModel<float> Capes { get; internal set; } = 0;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class DurabilityConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Axes { get; internal set; } = 0;
        public ConfigModel<float> Pickaxes { get; internal set; } = 0;
        public ConfigModel<float> Hammer { get; internal set; } = 0;
        public ConfigModel<float> Cultivator { get; internal set; } = 0;
        public ConfigModel<float> Hoe { get; internal set; } = 0;
        public ConfigModel<float> Weapons { get; internal set; } = 0;
        public ConfigModel<float> Armor { get; internal set; } = 0;
        public ConfigModel<float> Bows { get; internal set; } = 0;
        public ConfigModel<float> Shields { get; internal set; } = 0;
        public ConfigModel<float> Torch { get; internal set; } = 0;
    }
}

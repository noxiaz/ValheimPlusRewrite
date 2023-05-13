using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GatherConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Wood { get; internal set; } = 0;
        public ConfigModel<float> Stone { get; internal set; } = 0;
        public ConfigModel<float> FineWood { get; internal set; } = 0;
        public ConfigModel<float> CoreWood { get; internal set; } = 0;
        public ConfigModel<float> ElderBark { get; internal set; } = 0;
        public ConfigModel<float> IronScrap { get; internal set; } = 0;
        public ConfigModel<float> TinOre { get; internal set; } = 0;
        public ConfigModel<float> CopperOre { get; internal set; } = 0;
        public ConfigModel<float> SilverOre { get; internal set; } = 0;
        public ConfigModel<float> Chitin { get; internal set; } = 0;
        public ConfigModel<float> DropChance { get; internal set; } = 0;
    }
}

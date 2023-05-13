using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StaminaUsageConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Axes { get; internal set; } = 0;
        public ConfigModel<float> Bows { get; internal set; } = 0;
        public ConfigModel<float> Blocking { get; internal set; } = 0;
        public ConfigModel<float> Clubs { get; internal set; } = 0;
        public ConfigModel<float> Knives { get; internal set; } = 0;
        public ConfigModel<float> Pickaxes { get; internal set; } = 0;
        public ConfigModel<float> Polearms { get; internal set; } = 0;
        public ConfigModel<float> Spears { get; internal set; } = 0; 
        public ConfigModel<float> Swords { get; internal set; } = 0;
        public ConfigModel<float> Unarmed { get; internal set; } = 0;
        public ConfigModel<float> Hammer { get; internal set; } = 0;
        public ConfigModel<float> Hoe { get; internal set; } = 0;
        public ConfigModel<float> Cultivator { get; internal set; } = 0;
        public ConfigModel<float> Fishing { get; internal set; } = 0;
    }
}

using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StaminaUsageConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Each of these values change the respective tool in stamina usage by increases and reduction in percent declared by 50, or -50.")]
        public ConfigModel<float> Axes { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Bows { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Blocking { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Clubs { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Knives { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Pickaxes { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Polearms { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Spears { get; internal set; } = 0; 
        [ConfigDescription("")] 
        public ConfigModel<float> Swords { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Unarmed { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Hammer { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Hoe { get; internal set; } = 0;
        [ConfigDescription("")] 
        public ConfigModel<float> Cultivator { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Fishing { get; internal set; } = 0;
    }
}

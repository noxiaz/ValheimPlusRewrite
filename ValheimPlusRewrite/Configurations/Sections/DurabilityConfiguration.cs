using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class DurabilityConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Each of these values increase or reduce the durability of the specific item type by %. - The value 50 will increase the durability from 100 to 150. The value -50 will reduce the durability from 100 to 50.")]
        public ConfigModel<float> Axes { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Pickaxes { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Hammer { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Cultivator { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Hoe { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Weapons { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Armor { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Bows { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Shields { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Torch { get; internal set; } = 0;
    }
}

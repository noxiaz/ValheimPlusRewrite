using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GatherConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Modify the chance to drop resources from resource nodes affected by this category. This only works on resource nodes that do not have guaranteed drops. - As example by default scrap piles in dungeons have a 20% chance to drop a item, if you set this option to 200, you will then have a 60% chance to drop iron.")]
        public ConfigModel<float> DropChance { get; internal set; } = 0;
        [ConfigDescription("Each of these values increase or reduce the dropped items from destroyed objects with tools (Stones, Trees, Resource nodes, etc.) by %. - The value 50 will increase the dropped wood from trees from 10 to 15. The value -50 will reduce the amount of dropped wood from 10 to 5.")]
        public ConfigModel<float> Wood { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> Stone { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> FineWood { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> CoreWood { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> ElderBark { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> IronScrap { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> TinOre { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> CopperOre { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> SilverOre { get; internal set; } = 0;
        [ConfigDescription("Increase or decrease the dropped items from destroyed objects with tools by %.")]
        public ConfigModel<float> Chitin { get; internal set; } = 0;
    }
}

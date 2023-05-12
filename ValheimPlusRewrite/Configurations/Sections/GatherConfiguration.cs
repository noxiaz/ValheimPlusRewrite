using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GatherConfiguration : ServerSyncConfig
    {
        public float wood { get; internal set; } = 0;
        public float stone { get; internal set; } = 0;
        public float fineWood { get; internal set; } = 0;
        public float coreWood { get; internal set; } = 0;
        public float elderBark { get; internal set; } = 0;
        public float ironScrap { get; internal set; } = 0;
        public float tinOre { get; internal set; } = 0;
        public float copperOre { get; internal set; } = 0;
        public float silverOre { get; internal set; } = 0;
        public float chitin { get; internal set; } = 0;
        public float dropChance { get; internal set; } = 0;
    }
}

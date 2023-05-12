using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WagonConfiguration : ServerSyncConfig
    {
        public float wagonExtraMassFromItems { get; internal set; } = 0;
        public float wagonBaseMass { get; internal set; } = 20;
    }
}

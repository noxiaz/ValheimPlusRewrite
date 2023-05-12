using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ShieldConfiguration : ServerSyncConfig
    {
        public float blockRating { get; internal set; } = 0;
    }
}

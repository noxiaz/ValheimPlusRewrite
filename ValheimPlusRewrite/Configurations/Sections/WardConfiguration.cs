using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WardConfiguration : ServerSyncConfig
    {
        public float wardRange { get; internal set; } = 20;
        public float wardEnemySpawnRange { get; internal set; } = 0;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WardConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> WardRange { get; internal set; } = 20;
        public ConfigModel<float> WardEnemySpawnRange { get; internal set; } = 0;
    }
}

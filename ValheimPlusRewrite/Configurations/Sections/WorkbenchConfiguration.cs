using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WorkbenchConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> WorkbenchRange { get; internal set; } = 20;
        public ConfigModel<float> WorkbenchEnemySpawnRange { get; internal set; } = 0;
        public ConfigModel<float> WorkbenchAttachmentRange { get; internal set; } = 5.0f;
        public ConfigModel<bool> DisableRoofCheck { get; internal set; } = false;
    }
}

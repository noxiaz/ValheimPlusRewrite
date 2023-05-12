using ValheimPlusRewrite.Configurations.Abstracts;
namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WorkbenchConfiguration : ServerSyncConfig
    {
        public float workbenchRange { get; internal set; } = 20;
        public float workbenchEnemySpawnRange { get; internal set; } = 0;
        public float workbenchAttachmentRange { get; internal set; } = 5.0f;
        public bool disableRoofCheck { get; internal set; } = false;
    }
}

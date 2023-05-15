using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WorkbenchConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Set the workbench radius in meters.")] 
        public ConfigModel<float> WorkbenchRange { get; internal set; } = 20;
        [ConfigDescription("Set the enemy spawn radius around workbenches in meters - This value equals workbenchRange if its set to 0.")] 
        public ConfigModel<float> WorkbenchEnemySpawnRange { get; internal set; } = 0;
        [ConfigDescription("Sets the workbench attachment (e.g. anvil) radius.")] 
        public ConfigModel<float> WorkbenchAttachmentRange { get; internal set; } = 5.0f;
        [ConfigDescription("Disables the roof and exposure requirement to use a workbench.")] 
        public ConfigModel<bool> DisableRoofCheck { get; internal set; } = false;
    }
}

using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WardConfiguration : ServerSyncConfig
    {
        [Description("The range of wards by meters.")]
        public ConfigModel<float> WardRange { get; internal set; } = 20;
        [Description("Set the enemy spawn radius around wards in meters. - This value equals wardRange if its set to 0.")]
        public ConfigModel<float> WardEnemySpawnRange { get; internal set; } = 0;
    }
}

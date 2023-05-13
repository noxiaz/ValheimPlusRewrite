using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BeehiveConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> HoneyProductionSpeed { get; internal set; } = 1200;
        public ConfigModel<int> MaximumHoneyPerBeehive { get; internal set; } = 4;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        public ConfigModel<float> AutoDepositRange { get; internal set; } = 10;
        public ConfigModel<bool> ShowDuration { get; internal set; } = false;
    }

}

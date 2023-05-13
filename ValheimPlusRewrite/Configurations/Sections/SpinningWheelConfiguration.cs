using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class SpinningWheelConfiguration : ServerSyncConfig
    {
        public ConfigModel<int> MaximumFlax { get; internal set; } = 50;
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 30;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = true;
        public ConfigModel<bool> AutoFuel { get; internal set; } = true;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

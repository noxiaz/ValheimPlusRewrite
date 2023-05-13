using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WindmillConfiguration : ServerSyncConfig
    {
        public ConfigModel<int> MaximumBarley { get; internal set; } = 50;
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 10;
        public ConfigModel<bool> IgnoreWindIntensity { get; internal set; } = false;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

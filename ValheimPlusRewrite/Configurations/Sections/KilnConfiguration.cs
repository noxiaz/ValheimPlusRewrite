using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class KilnConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> productionSpeed { get; internal set; } = 15;
        public ConfigModel<int> MaximumWood { get; internal set; } = 25;
        public ConfigModel<bool> DontProcessFineWood { get; internal set; } = false;
        public ConfigModel<bool> DontProcessRoundLog { get; internal set; } = false;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        public ConfigModel<int> StopAutoFuelThreshold { get; internal set; } = 0;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }

}

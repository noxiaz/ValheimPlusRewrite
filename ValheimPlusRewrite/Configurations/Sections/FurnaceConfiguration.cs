using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FurnaceConfiguration : ServerSyncConfig
    {
        public ConfigModel<int> MaximumOre { get; internal set; } = 10;
        public ConfigModel<int> MaximumCoal { get; internal set; } = 20;
        public ConfigModel<int> CoalUsedPerProduct { get; internal set; } = 2;
        public ConfigModel<float> ProductionSpeed { get; internal set; } = 30;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
        public ConfigModel<bool> AllowAllOres { get; internal set; } = false;
    }

}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FermenterConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> FermenterDuration { get; internal set; } = 2400;
        public ConfigModel<int> FermenterItemsProduced { get; internal set; } = 4;
        public ConfigModel<bool> ShowDuration { get; internal set; } = false;
        public ConfigModel<bool> AutoDeposit { get; internal set; } = false;
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = false;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }

}

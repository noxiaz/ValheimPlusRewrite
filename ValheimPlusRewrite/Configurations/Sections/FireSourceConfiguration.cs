using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FireSourceConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> Torches { get; internal set; } = false;
        public ConfigModel<bool> Fires { get; internal set; } = false;
        public ConfigModel<bool> AutoFuel { get; internal set; } = false;
        public ConfigModel<bool> IgnorePrivateAreaCheck { get; internal set; } = true;
        public ConfigModel<float> AutoRange { get; internal set; } = 10;
    }
}

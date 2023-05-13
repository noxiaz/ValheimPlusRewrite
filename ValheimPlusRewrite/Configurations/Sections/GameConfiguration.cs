using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GameConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> GameDifficultyDamageScale { get; internal set; } = 4f;
        public ConfigModel<float> GameDifficultyHealthScale { get; internal set; } = 30f;
        public ConfigModel<int> ExtraPlayerCountNearby { get; internal set; } = 0;
        public ConfigModel<int> SetFixedPlayerCountTo { get; internal set; } = 0;
        public ConfigModel<int> DifficultyScaleRange { get; internal set; } = 200;
        public ConfigModel<bool> DisablePortals { get; internal set; } = false;
        public ConfigModel<bool> DisableConsole { get; internal set; } = false;
        public ConfigModel<bool> BigPortalNames { get; internal set; } = false;
        public ConfigModel<bool> DisableFog { get; internal set; } = false;
    }
}

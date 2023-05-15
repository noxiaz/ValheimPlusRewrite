using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GameConfiguration : ServerSyncConfig
    {
        [ConfigDescription("The games damage multiplier per person nearby in difficultyScaleRange(m) radius.")]
        public ConfigModel<float> GameDifficultyDamageScale { get; internal set; } = 4f;
        [ConfigDescription("The games health multiplier per person nearby in difficultyScaleRange(m) radius.")]
        public ConfigModel<float> GameDifficultyHealthScale { get; internal set; } = 30f;
        [ConfigDescription("Adds additional players to the difficulty calculation in multiplayer unrelated to the actual amount.")]
        public ConfigModel<int> ExtraPlayerCountNearby { get; internal set; } = 0;
        [ConfigDescription("Sets the nearby player count always to this value + extraPlayerCountNearby.")]
        public ConfigModel<int> SetFixedPlayerCountTo { get; internal set; } = 0;
        [ConfigDescription("The range in meters at which other players count towards nearby players for the difficulty scale.")]
        public ConfigModel<int> DifficultyScaleRange { get; internal set; } = 200;
        [ConfigDescription("If you set this to true, all portals will be disabled.")]
        public ConfigModel<bool> DisablePortals { get; internal set; } = false;
        [ConfigDescription("If you set this to true the console will be force disabled in-game.")]
        public ConfigModel<bool> DisableConsole { get; internal set; } = false;
        [ConfigDescription("If you set this to true, portal names will be displayed in big text in center of screen.")]
        public ConfigModel<bool> BigPortalNames { get; internal set; } = false;
        [ConfigDescription("Remove dense fog from the game.")]
        public ConfigModel<bool> DisableFog { get; internal set; } = false;
    }
}

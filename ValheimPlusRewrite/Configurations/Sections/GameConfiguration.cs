﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GameConfiguration : ServerSyncConfig
    {
        public float gameDifficultyDamageScale { get; internal set; } = 4f;
        public float gameDifficultyHealthScale { get; internal set; } = 30f;
        public int extraPlayerCountNearby { get; internal set; } = 0;
        public int setFixedPlayerCountTo { get; internal set; } = 0;
        public int difficultyScaleRange { get; internal set; } = 200;
        public bool disablePortals { get; internal set; } = false;
        public bool disableConsole { get; internal set; } = false;
        public bool bigPortalNames { get; internal set; } = false;
        public bool disableFog { get; internal set; } = false;
    }
}

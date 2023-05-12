﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class SpinningWheelConfiguration : ServerSyncConfig
    {
        public int maximumFlax { get; internal set; } = 50;
        public float productionSpeed { get; internal set; } = 30;
        public bool autoDeposit { get; internal set; } = true;
        public bool autoFuel { get; internal set; } = true;
        public bool ignorePrivateAreaCheck { get; internal set; } = true;
        public float autoRange { get; internal set; } = 10;
    }
}

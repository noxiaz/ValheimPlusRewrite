﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class KilnConfiguration : ServerSyncConfig
    {
        public float productionSpeed { get; internal set; } = 15;
        public int maximumWood { get; internal set; } = 25;
        public bool dontProcessFineWood { get; internal set; } = false;
        public bool dontProcessRoundLog { get; internal set; } = false;
        public bool autoDeposit { get; internal set; } = false;
        public bool autoFuel { get; internal set; } = false;
        public int stopAutoFuelThreshold { get; internal set; } = 0;
        public bool ignorePrivateAreaCheck { get; internal set; } = true;
        public float autoRange { get; internal set; } = 10;
    }

}

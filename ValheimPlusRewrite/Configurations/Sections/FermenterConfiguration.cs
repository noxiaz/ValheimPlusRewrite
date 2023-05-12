﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FermenterConfiguration : ServerSyncConfig
    {
        public float fermenterDuration { get; internal set; } = 2400;
        public int fermenterItemsProduced { get; internal set; } = 4;
        public bool showDuration { get; internal set; } = false;
        public bool autoDeposit { get; internal set; } = false;
        public bool autoFuel { get; internal set; } = false;
        public bool ignorePrivateAreaCheck { get; internal set; } = false;
        public float autoRange { get; internal set; } = 10;
    }

}

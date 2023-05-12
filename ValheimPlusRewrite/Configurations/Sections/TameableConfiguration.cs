using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TameableConfiguration : ServerSyncConfig
    {
        public int mortality { get; internal set; } = 0;
        public bool ownerDamageOverride { get; internal set; } = false;
        public float stunRecoveryTime { get; internal set; } = 10f;
        public bool stunInformation { get; internal set; } = false;
    }
}

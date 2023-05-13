using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TameableConfiguration : ServerSyncConfig
    {
        public ConfigModel<int> Mortality { get; internal set; } = 0;
        public ConfigModel<bool> OwnerDamageOverride { get; internal set; } = false;
        public ConfigModel<float> StunRecoveryTime { get; internal set; } = 10f;
        public ConfigModel<bool> StunInformation { get; internal set; } = false;
    }
}

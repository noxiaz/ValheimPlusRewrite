using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class TameableConfiguration : ServerSyncConfig
    {
        [Description("Modify what happens when a tamed creature is attacked. - 0 = normal, 1 = essential(deadly attacks stun instead of kill, tamed creatures can still die rarely), 2 = immortal.")]
        public ConfigModel<int> Mortality { get; internal set; } = 0;
        [Description("This will circumvent the mortality setting, so even if tamed creatures are immortal, players can still kill them with a butcher knife. - For this option to work you need to have mortality to set to either essential or immortal.")]
        public ConfigModel<bool> OwnerDamageOverride { get; internal set; } = false;
        [Description("How long it takes for a tamed creature to recover if mortality is set to 1(essential) and they are stunned.")]
        public ConfigModel<float> StunRecoveryTime { get; internal set; } = 10f;
        [Description("If the tamed creature is recovering from a stun, then add Stunned to the hover text on mouse over.")]
        public ConfigModel<bool> StunInformation { get; internal set; } = false;
    }
}

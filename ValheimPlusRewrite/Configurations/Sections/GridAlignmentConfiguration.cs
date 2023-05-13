using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GridAlignmentConfiguration : ServerSyncConfig
    {
        public ConfigModel<KeyCode> Align { get; internal set; } = KeyCode.LeftAlt;
        public ConfigModel<KeyCode> AlignToggle { get; internal set; } = KeyCode.F7;
        public ConfigModel<KeyCode> ChangeDefaultAlignment { get; internal set; } = KeyCode.F6;
    }
}

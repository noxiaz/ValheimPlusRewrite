using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class HotkeyConfiguration : BaseConfig
    {
        public ConfigModel<KeyCode> RollForwards { get; internal set; } = KeyCode.F9;
        public ConfigModel<KeyCode> RollBackwards { get; internal set; } = KeyCode.F10;
    }
}

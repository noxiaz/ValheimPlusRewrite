using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class HotkeyConfiguration : BaseConfig
    {
        public KeyCode rollForwards { get; internal set; } = KeyCode.F9;
        public KeyCode rollBackwards { get; internal set; } = KeyCode.F10;
    }
}

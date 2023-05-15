using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GridAlignmentConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Key to enable grid alignment.")] 
        public ConfigModel<KeyCode> Align { get; internal set; } = KeyCode.LeftAlt;
        [ConfigDescription("Key to toggle grid alignment.")] 
        public ConfigModel<KeyCode> AlignToggle { get; internal set; } = KeyCode.F7;
        [ConfigDescription("Key to change the default alignment.")] 
        public ConfigModel<KeyCode> ChangeDefaultAlignment { get; internal set; } = KeyCode.F6;
    }
}

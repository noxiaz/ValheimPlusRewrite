﻿using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ArmorConfiguration : ServerSyncConfig
    {
        [ConfigDescription("Each of these values increase or reduce the armor of the specific item type by %.")]
        [ConfigDescription("The value 50 will increase the armor from 14 to 21. The value -50 will reduce the armor from 14 to 7.")]
        public ConfigModel<float> Helmets { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Chests { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Legs { get; internal set; } = 0;
        [ConfigDescription("")]
        public ConfigModel<float> Capes { get; internal set; } = 0;
    }
}

﻿using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class CameraConfiguration : BaseConfig
    {
        [ConfigDescription("The maximum zoom distance to your character in-game.")]
        public ConfigModel<float> CameraMaximumZoomDistance { get; internal set; } = 6;
        [ConfigDescription("The maximum zoom distance to your character when in a boat.")]
        public ConfigModel<float> CameraBoatMaximumZoomDistance { get; internal set; } = 6;
        [ConfigDescription("The in-game camera FOV.")]
        public ConfigModel<float> CameraFOV { get; internal set; } = 65;
    }
}

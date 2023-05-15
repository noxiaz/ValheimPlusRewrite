using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FreePlacementRotationConfiguration : BaseConfig
    {
        [ConfigDescription("Rotates placement marker by 1 degree with keep ability to attach to nearly pieces.")]
        public ConfigModel<KeyCode> RotateY { get; internal set; } = KeyCode.LeftAlt;
        [ConfigDescription("")]
        public ConfigModel<KeyCode> RotateX { get; internal set; } = KeyCode.C;
        [ConfigDescription("")]
        public ConfigModel<KeyCode> RotateZ { get; internal set; } = KeyCode.V;
        [ConfigDescription("Copy rotation of placement marker from target piece in front of you.")]
        public ConfigModel<KeyCode> CopyRotationParallel  { get; internal set; } = KeyCode.F;
        [ConfigDescription("Set rotation to be perpendicular to piece in front of you.")]
        public ConfigModel<KeyCode> CopyRotationPerpendicular  { get; internal set; } = KeyCode.G;
    }
}

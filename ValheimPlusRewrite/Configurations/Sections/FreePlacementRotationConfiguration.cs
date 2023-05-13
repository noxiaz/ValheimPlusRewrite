using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FreePlacementRotationConfiguration : BaseConfig
    {
        public ConfigModel<KeyCode> RotateY { get; internal set; } = KeyCode.LeftAlt;
        public ConfigModel<KeyCode> RotateX { get; internal set; } = KeyCode.C;
        public ConfigModel<KeyCode> RotateZ { get; internal set; } = KeyCode.V;
        public ConfigModel<KeyCode> CopyRotationParallel  { get; internal set; } = KeyCode.F;
        public ConfigModel<KeyCode> CopyRotationPerpendicular  { get; internal set; } = KeyCode.G;
    }
}

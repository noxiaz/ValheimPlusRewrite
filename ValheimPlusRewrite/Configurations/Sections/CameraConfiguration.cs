using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class CameraConfiguration : BaseConfig
    {
        public ConfigModel<float> CameraMaximumZoomDistance { get; internal set; } = 1146;
        public ConfigModel<float> CameraBoatMaximumZoomDistance { get; internal set; } = 6;
        public ConfigModel<float> CameraFOV { get; internal set; } = 65;
    }
}

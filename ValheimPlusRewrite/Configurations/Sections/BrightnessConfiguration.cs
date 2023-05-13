using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BrightnessConfiguration : BaseConfig
    {
        /* changing brightness during a period of day had a coupling affect with other period, need further development
        public float morningBrightnessMultiplier { get; set; } = 0f;
        public float dayBrightnessMultiplier { get; set; } = 0f;
        public float eveningBrightnessMultiplier { get; set; } = 0f;
        */
        public ConfigModel<float> nightBrightnessMultiplier { get; set; } = 0f;
    }
}
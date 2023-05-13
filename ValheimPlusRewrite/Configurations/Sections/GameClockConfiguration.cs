using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;
namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GameClockConfiguration : ServerSyncConfig
    {
        public ConfigModel<bool> UseAMPM { get; set; } = false;
        public ConfigModel<int> TextFontSize { get; set; } = 34;
        public ConfigModel<int> TextRedChannel { get; set; } = 248;
        public ConfigModel<int> TextGreenChannel { get; set; } = 105;
        public ConfigModel<int> TextBlueChannel { get; set; } = 0;
        public ConfigModel<int> TextTransparencyChannel { get; set; } = 255;
    }
}
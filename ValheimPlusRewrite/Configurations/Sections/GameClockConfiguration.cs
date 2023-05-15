using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;
namespace ValheimPlusRewrite.Configurations.Sections
{
    public class GameClockConfiguration : ServerSyncConfig
    {
        [Description("Change time formatting from 24hr to AM-PM.")]
        public ConfigModel<bool> UseAMPM { get; set; } = false;
        [Description("Change font size of time text.")]
        public ConfigModel<int> TextFontSize { get; set; } = 34;
        [Description("Change how red the time text is (51/255).")]
        public ConfigModel<int> TextRedChannel { get; set; } = 248;
        [Description("Change how green the time text is (51/255).")]
        public ConfigModel<int> TextGreenChannel { get; set; } = 105;
        [Description("Change how blue the time text is (51/255).")]
        public ConfigModel<int> TextBlueChannel { get; set; } = 0;
        [Description("Change how transparent the time text is (255 is solid with no transparency).")]
        public ConfigModel<int> TextTransparencyChannel { get; set; } = 255;
    }
}
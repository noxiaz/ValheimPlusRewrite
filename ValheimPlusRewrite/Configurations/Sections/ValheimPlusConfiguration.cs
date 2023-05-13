using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ValheimPlusConfiguration : BaseConfig
    {
        public ConfigModel<bool> MainMenuLogo { get; internal set; } = true;
        public ConfigModel<bool> ServerBrowserAdvertisement { get; internal set; } = true;
    }
}

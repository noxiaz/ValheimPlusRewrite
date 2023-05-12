using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ValheimPlusConfiguration : BaseConfig
    {
        public bool mainMenuLogo { get; internal set; } = true;
        public bool serverBrowserAdvertisement { get; internal set; } = true;
    }
}

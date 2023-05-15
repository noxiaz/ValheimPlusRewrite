using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ValheimPlusConfiguration : BaseConfig
    {
        [Description("Display the Valheim Plus logo in the main menu")]
        public ConfigModel<bool> MainMenuLogo { get; internal set; } = true;
    }
}

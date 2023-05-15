using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class DeconstructConfiguration : BaseConfig
    {
        [ConfigDescription("NOT IMPLEMENTED - ITS NOT DONE")]
        public ConfigModel<int> PercentageOfReturnedResource { get; internal set; } = 100;
    }
}
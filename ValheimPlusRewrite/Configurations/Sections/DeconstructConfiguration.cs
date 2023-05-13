using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class DeconstructConfiguration : BaseConfig
    {
        public ConfigModel<int> PercentageOfReturnedResource { get; internal set; } = 100;
    }
}
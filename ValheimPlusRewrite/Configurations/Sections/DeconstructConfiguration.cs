using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class DeconstructConfiguration : BaseConfig
    {
        public int percentageOfReturnedResource { get; internal set; } = 100;
    }
}
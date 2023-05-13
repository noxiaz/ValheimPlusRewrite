using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PickableConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Edibles { get; internal set; } = 0;
        public ConfigModel<float> FlowersAndIngredients { get; internal set; } = 0;
        public ConfigModel<float> Materials { get; internal set; } = 0;
        public ConfigModel<float> Valuables { get; internal set; } = 0;
        public ConfigModel<float> SurtlingCores { get; internal set; } = 0;
    }
}

using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class FoodConfiguration : ServerSyncConfig
    {
        [Description("Increase or reduce the time that food lasts by %. - The value 50 would cause food to run out 50% slower, -50% would cause the food to run out 50% faster.")]
        public ConfigModel<float> FoodDurationMultiplier { get; internal set; } = 0;
        [Description("This option prevents food degrading over time - in other words, it retains its maximum benefit until it runs out instead of reducing its effect over time.")]
        public ConfigModel<bool> DisableFoodDegradation { get; internal set; } = false;
    }
}

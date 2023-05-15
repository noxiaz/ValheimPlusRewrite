using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class WagonConfiguration : ServerSyncConfig
    {
        [Description("Change the base wagon physical mass of the wagon object. - This is essentially the base weight of a cart.")] 
        public ConfigModel<float> WagonBaseMass { get; internal set; } = 20;
        [Description("This value changes the physical weight of wagons by +/- more/less from item weight inside. - The value 50 would increase the weight by 50% more. The value -100 would remove the entire extra weight.")] 
        public ConfigModel<float> WagonExtraMassFromItems { get; internal set; } = 0;
    }
}

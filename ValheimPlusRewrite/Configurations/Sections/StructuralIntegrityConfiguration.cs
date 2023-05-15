using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StructuralIntegrityConfiguration : ServerSyncConfig
    {
        [Description("Disables the entire structural integrity system and allows for placement in free air, does not prevent building damage.")] 
        public ConfigModel<bool> DisableStructuralIntegrity { get; internal set; } = false;
        [Description("Disables any damage from anything to all player built structures. Does not prevent damage from structural integrity.")] 
        public ConfigModel<bool> DisableDamageToPlayerStructures { get; internal set; } = false;
        [Description("Disables any damage from anything to all player built boats")] 
        public ConfigModel<bool> DisableDamageToPlayerBoats { get; internal set; } = false;
        [Description("Disables water force damage to all player built boats.")] 
        public ConfigModel<bool> DisableDamageToPlayerCarts { get; internal set; } = false;
        [Description("Disables any damage from anything to all player built carts.")] 
        public ConfigModel<bool> DisableWaterDamageToPlayerBoats { get; internal set; } = false;
        [Description("Disables water force damage to all player built carts.")]
        public ConfigModel<bool> DisableWaterDamageToPlayerCarts { get; internal set; } = false;
        [Description("Each of these values reduce the loss of structural integrity by distance by % less. - The value 100 would result in disabled structural integrity over distance, does not allow for placement in free air without disableStructuralIntegrity.")]
        public ConfigModel<float> Wood { get; internal set; } = 0;
        [Description("")] 
        public ConfigModel<float> Stone { get; internal set; } = 0;
        [Description("")] 
        public ConfigModel<float> Iron { get; internal set; } = 0;
        [Description("")] 
        public ConfigModel<float> HardWood { get; internal set; } = 0;
        [Description("")] 
        public ConfigModel<float> Marble { get; internal set; } = 0;
    }
}

using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class StructuralIntegrityConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Wood { get; internal set; } = 0;
        public ConfigModel<float> Stone { get; internal set; } = 0;
        public ConfigModel<float> Iron { get; internal set; } = 0;
        public ConfigModel<float> HardWood { get; internal set; } = 0;
        public ConfigModel<float> Marble { get; internal set; } = 0;
        public ConfigModel<bool> DisableStructuralIntegrity { get; internal set; } = false;
        public ConfigModel<bool> DisableDamageToPlayerStructures { get; internal set; } = false;
        public ConfigModel<bool> DisableDamageToPlayerBoats { get; internal set; } = false;
        public ConfigModel<bool> DisableDamageToPlayerCarts { get; internal set; } = false;
        public ConfigModel<bool> DisableWaterDamageToPlayerBoats { get; internal set; } = false;
        public ConfigModel<bool> DisableWaterDamageToPlayerCarts { get; internal set; } = false;
    }
}

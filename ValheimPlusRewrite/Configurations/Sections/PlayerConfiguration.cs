using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PlayerConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> BaseMaximumWeight { get; internal set; } = 300;
        public ConfigModel<float> BaseMegingjordBuff { get; internal set; } = 150;
        public ConfigModel<float> BaseAutoPickUpRange { get; internal set; } = 2;
        public ConfigModel<bool> DisableCameraShake { get; internal set; } = false;
        public ConfigModel<float> BaseUnarmedDamage { get; internal set; } = 0;
        public ConfigModel<bool> CropNotifier { get; internal set; } = false;
        public ConfigModel<float> RestSecondsPerComfortLevel { get; internal set; } = 60;
        public ConfigModel<float> DeathPenaltyMultiplier { get; internal set; } = 0;
        public ConfigModel<bool> AutoRepair { get; internal set; } = false;
        public ConfigModel<float> GuardianBuffDuration { get; internal set; } = 300;
        public ConfigModel<float> GuardianBuffCooldown { get; internal set; } = 1200;
        public ConfigModel<bool> DisableGuardianBuffAnimation { get; internal set; } = false;
        public ConfigModel<bool> AutoEquipShield { get; internal set; } = false;
        public ConfigModel<bool> AutoUnequipShield { get; internal set; } = false;
        public ConfigModel<bool> SkipIntro { get; internal set; } = false;
        public ConfigModel<bool> IHaveArrivedOnSpawn { get; internal set; } = true;
        public ConfigModel<bool> QueueWeaponChanges { get; internal set; } = false;
        public ConfigModel<bool> DontUnequipItemsWhenSwimming { get; internal set; } = false;
        public ConfigModel<bool> ReequipItemsAfterSwimming { get; internal set; } = false;
        public ConfigModel<float> FallDamageScalePercent { get; internal set; } = 0;
        public ConfigModel<float> MaxFallDamage { get; internal set; } = 100;
        public ConfigModel<bool> SkipTutorials { get; internal set; } = false;
        public ConfigModel<bool> DisableEncumbered { get; internal set; } = false;
        public ConfigModel<bool> DutoPickUpWhenEncumbered { get; internal set; } = false;
    }
}

using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PlayerConfiguration : ServerSyncConfig
    {
        [ConfigDescription("The base amount of carry weight of your character.")] 
        public ConfigModel<float> BaseMaximumWeight { get; internal set; } = 300;
        [ConfigDescription("Increase the buff you receive to your carry weight from Megingjord's girdle.")] 
        public ConfigModel<float> BaseMegingjordBuff { get; internal set; } = 150;
        [ConfigDescription("Increase auto pickup range of all items.")] 
        public ConfigModel<float> BaseAutoPickUpRange { get; internal set; } = 2;
        [ConfigDescription("Disable all types of camera shake.")] 
        public ConfigModel<bool> DisableCameraShake { get; internal set; } = false;
        [ConfigDescription("The base unarmed damage multiplied by your skill level. 120 will result in a maximum of up to 12 damage when you have a skill level of 10.")] 
        public ConfigModel<float> BaseUnarmedDamage { get; internal set; } = 0;
        [ConfigDescription("When changed to true, you will not be permitted to place a crop within the grow radius of another crop.")] 
        public ConfigModel<bool> CropNotifier { get; internal set; } = false;
        [ConfigDescription("How many seconds each comfort level contributes to the rested bonus.")] 
        public ConfigModel<float> RestSecondsPerComfortLevel { get; internal set; } = 60;
        [ConfigDescription("Change the death penalty in percentage, where higher will increase the death penalty and lower will reduce it. - This is a modifier value. 50 will increase it by 50%, -50 will reduce it by 50%.")] 
        public ConfigModel<float> DeathPenaltyMultiplier { get; internal set; } = 0;
        [ConfigDescription("If set to true, this option will automatically repair your equipment when you interact with the appropriate workbench.")] 
        public ConfigModel<bool> AutoRepair { get; internal set; } = false;
        [ConfigDescription("Boss buff duration (seconds)")] 
        public ConfigModel<float> GuardianBuffDuration { get; internal set; } = 300;
        [ConfigDescription("Boss buff cooldown (seconds)")] 
        public ConfigModel<float> GuardianBuffCooldown { get; internal set; } = 1200;
        [ConfigDescription("Disable the Guardian Buff animation")] 
        public ConfigModel<bool> DisableGuardianBuffAnimation { get; internal set; } = false;
        [ConfigDescription("If set to true, when equipping a one-handed weapon, the best shield from your inventory is automatically equipped. - (Best is determined by highest block power)")] 
        public ConfigModel<bool> AutoEquipShield { get; internal set; } = false;
        [ConfigDescription("When unequipping a one-handed weapon also unequip shield from inventory.")] 
        public ConfigModel<bool> AutoUnequipShield { get; internal set; } = false;
        [ConfigDescription("If set to true, weapon switches requested mid-attack will be carried out when the current attack is finished instead of being ignored.")] 
        public ConfigModel<bool> QueueWeaponChanges { get; internal set; } = false;
        [ConfigDescription("If set to true, you will always skip the intro of the game.")]
        public ConfigModel<bool> SkipIntro { get; internal set; } = false;
        [ConfigDescription("If set to false, disables the \"I have arrived!\" message on player spawn.")]
        public ConfigModel<bool> IHaveArrivedOnSpawn { get; internal set; } = true;
        [ConfigDescription("If set to true, you will not put away / unequip your items when swimming.")] 
        public ConfigModel<bool> DontUnequipItemsWhenSwimming { get; internal set; } = false;
        [ConfigDescription("If set to true, items will be re-equipped when you exit water after swimming (if they were hidden automatically)")] 
        public ConfigModel<bool> ReequipItemsAfterSwimming { get; internal set; } = false;
        [ConfigDescription("This value represents how much the fall damage should be scaled in +/- %. This is a modifier value. - The value 50 would result in 50% increased fall damage. The value -50 would result in 50% reduced fall damage.")] 
        public ConfigModel<float> FallDamageScalePercent { get; internal set; } = 0;
        [ConfigDescription("Max fall damage. Game default is 100 (so with enough health, falls can't kill).")] 
        public ConfigModel<float> MaxFallDamage { get; internal set; } = 100;
        [ConfigDescription("If set to true, all tutorials will skip from now on. You can turn this config off and reset the tutorial (in the settings) at any time.")] 
        public ConfigModel<bool> SkipTutorials { get; internal set; } = false;
        [ConfigDescription("Disable the encumbered state when you carry too many items (overweight)")] 
        public ConfigModel<bool> DisableEncumbered { get; internal set; } = false;
        [ConfigDescription("Allow auto pickup of items when encumbered (overweight)")] 
        public ConfigModel<bool> AutoPickUpWhenEncumbered { get; internal set; } = false;
    }
}

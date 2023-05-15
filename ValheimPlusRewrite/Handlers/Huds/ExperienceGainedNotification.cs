using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Sections;

namespace ValheimPlusRewrite.Handlers.Huds
{
    [ConfigHandler(typeof(HudConfiguration), nameof(HudConfiguration.ExperienceGainedNotifications))]
    internal static class ExperienceGainedNotification
    {
        [HarmonyPatch(typeof(Skills), nameof(Skills.RaiseSkill))]
        [HarmonyPostfix]
        private static void Skills_RaiseSkill_Postfix(Skills __instance, Skills.SkillType skillType, float factor = 1f)
        {
            if (Configuration.Current.Hud.IsEnabled && Configuration.Current.Hud.ExperienceGainedNotifications && skillType != Skills.SkillType.None)
            {
                try
                {
                    Skills.Skill skill;
                    skill = __instance.GetSkill(skillType);
                    float percent = skill.m_accumulator / (skill.GetNextLevelRequirement() / 100);
                    __instance.m_player.Message(MessageHud.MessageType.TopLeft, "Level " + skill.m_level.Truncate(0) + " " + skill.m_info.m_skill
                                                + " [" + skill.m_accumulator.Truncate(2) + "/" + skill.GetNextLevelRequirement().Truncate(2) + "]"
                                                + " (" + percent.Truncate(0) + "%)", 0, skill.m_info.m_icon);
                }
                catch (Exception ex)
                {
                    Log.LogError(ex);
                    return;
                }
            }
        }
    }
}

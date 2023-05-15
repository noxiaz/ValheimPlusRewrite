using System.ComponentModel;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BedConfiguration : BaseConfig
    {
        [Description("Change false to true to enable sleeping without setting bed as spawn.")]
        public ConfigModel<bool> SleepWithoutSpawn { get; set; } = false;
        [Description("Change false to true to enable sleeping on only unclaimed beds without setting bed as spawn.")]
        public ConfigModel<bool> UnclaimedBedsOnly { get; set; } = false;
    }
}
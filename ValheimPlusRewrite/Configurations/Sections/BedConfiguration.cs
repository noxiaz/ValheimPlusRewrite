using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BedConfiguration : BaseConfig
    {
        public ConfigModel<bool> SleepWithoutSpawn { get; set; } = false;
        public ConfigModel<bool> UnclaimedBedsOnly { get; set; } = false;
    }
}
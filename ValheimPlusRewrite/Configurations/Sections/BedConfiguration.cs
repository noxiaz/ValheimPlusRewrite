using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BedConfiguration : BaseConfig
    {
        public ConfigModel<bool> sleepWithoutSpawn { get; set; } = false;
        public ConfigModel<bool> unclaimedBedsOnly { get; set; } = false;
    }
}
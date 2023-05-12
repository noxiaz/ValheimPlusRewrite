using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BedConfiguration : BaseConfig
    {
        public bool sleepWithoutSpawn { get; set; } = false;
        public bool unclaimedBedsOnly { get; set; } = false;
    }
}
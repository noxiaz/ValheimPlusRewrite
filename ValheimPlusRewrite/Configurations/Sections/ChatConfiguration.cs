using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ChatConfiguration : BaseConfig
    {
        public ConfigModel<float> ShoutDistance { get; internal set; } = 125;
        public ConfigModel<float> PingDistance { get; internal set; } = 125;
        public ConfigModel<bool> ForcedCase { get; internal set; } = true;
        public ConfigModel<bool> OutOfRangeShoutsDisplayInChatWindow { get; internal set; } = true;
        public ConfigModel<float> DefaultWhisperDistance { get; internal set; } = 4;
        public ConfigModel<float> DefaultNormalDistance { get; internal set; } = 15;
        public ConfigModel<float> DefaultShoutDistance { get; internal set; } = 70;
    }
}

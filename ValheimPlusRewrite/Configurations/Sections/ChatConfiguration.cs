using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ChatConfiguration : BaseConfig
    {
        [Description("If the player is outside of this range in meters in comparison to the creator of the shout you will not see the message on the map or in the chat. If this is set to 0, its disabled.")]
        public ConfigModel<float> ShoutDistance { get; internal set; } = 125;
        [Description("With this option enabled you will see the shout message in your chat window even if you are outside of shoutDistance.")]
        public ConfigModel<bool> OutOfRangeShoutsDisplayInChatWindow { get; internal set; } = true;
        [Description("If the player is outside of this range in meters in comparison to the creator of the ping on the map you will not see the ping on the map. If this is set to 0, its disabled.")]
        public ConfigModel<float> PingDistance { get; internal set; } = 125;
        [Description("Disable the forced upper and lower case conversions for in-game text messages of all types.")]
        public ConfigModel<bool> ForcedCase { get; internal set; } = true;
        [Description("This value determines the range in meters that you can see whisper text messages by default.")]
        public ConfigModel<float> DefaultWhisperDistance { get; internal set; } = 4;
        [Description("This value determines the range in meters that you can see normal text messages by default.")]
        public ConfigModel<float> DefaultNormalDistance { get; internal set; } = 15;
        [Description("This value determines the range in meters that you can see shout text messages by default.")]
        public ConfigModel<float> DefaultShoutDistance { get; internal set; } = 70;
    }
}

using System.ComponentModel;
using System.Security.Policy;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Enums;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ServerConfiguration : BaseConfig
    {
        [ConfigDescription("Modify the maximum amount of players on your Server.")]
        public ConfigModel<int> MaxPlayers { get; internal set; } = 10;
        [ConfigDescription("Removes the requirement to have a server password.")]
        public ConfigModel<bool> DisableServerPassword { get; internal set; } = false;
        [ConfigDescription("This settings add a version control check to make sure that people that try to join your game or the server you try to join has V+ installed - WE HEAVILY RECOMMEND TO NEVER DISABLE THIS!")]
        public ConfigModel<bool> EnforceMod { get; internal set; } = true;
        /// <summary>
        /// Changes whether the server will force it's config on clients that connect. Only affects servers.
        /// WE HEAVILY RECOMMEND TO NEVER DISABLE THIS! 
        /// </summary>
        [LoadingOption(LoadingMode.RemoteOnly)]
        [ConfigDescription("Changes whether the server will force it's config on clients that connect. Only affects servers. - WE HEAVILY RECOMMEND TO NEVER DISABLE THIS!")]
        public ConfigModel<bool> ServerSyncsConfig { get; internal set; } = true;
        /// <summary>
        /// If false allows you to keep your own defined hotkeys instead of synchronising the ones declared for the server.
        /// Sections need to be enabled in your local configuration to load hotkeys.
        /// This is a client side setting and not affected by server settings.
        /// </summary>
        [LoadingOption(LoadingMode.LocalOnly)]
        [ConfigDescription("If false allows you to keep your own defined hotkeys instead of synchronising the ones declared for the server.")]
        public ConfigModel<bool> ServerSyncHotkeys { get; internal set; } = false;
        public override bool IsEnabled { get; set; } = true;
    }

}

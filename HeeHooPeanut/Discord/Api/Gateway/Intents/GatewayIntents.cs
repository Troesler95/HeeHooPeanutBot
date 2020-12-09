using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Intents
{
    [Flags]
    public enum GatewayIntents
    {
        /// <summary>
        /// This intent includes no events
        /// </summary>
        None = 0,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>GUILD_CREATE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_DELETE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_ROLE_CREATE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_ROLE_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_ROLE_DELETE</description>
        /// </item>
        /// <item>
        /// <description>CHANNEL_CREATE</description>
        /// </item>
        /// <item>
        /// <description>CHANNEL_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>CHANNEL_DELETE</description>
        /// </item>
        /// <item>
        /// <description>CHANNEL_PINS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        Guilds = 1 << 0,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>GUILD_MEMBER_ADD</description>
        /// </item>
        /// <item>
        /// <description>GUILD_MEMBER_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>GUILD_MEMBER_REMOVE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildMembers = 1 << 1,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>GUILD_BAN_ADD</description>
        /// </item>
        /// <item>
        /// <description>GUILD_BAN_REMOVE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildBans = 1 << 2,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>GUILD_EMOJIS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildEmojis = 1 << 3,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>GUILD_INTEGRATIONS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildIntegrations = 1 << 4,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>WEBHOOKS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildWebhooks = 1 << 5,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>INVITE_CREATE</description>
        /// </item>
        /// <item>
        /// <description>INVITE_DELETE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildInvites = 1 << 6,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>VOICE_STATUS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildVoiceStates = 1 << 7,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>PRESENCE_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildPresences = 1 << 8,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>MESSAGE_CREATE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_DELETE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_DELETE_BULK</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildMessages = 1 << 9,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>MESSAGE_REACTION_ADD</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE_ALL</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE_EMOJI</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildMessageReactions = 1 << 10,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>TYPING_START</description>
        /// </item>
        /// </list>
        /// </summary>
        GuildMessageTyping = 1 << 11,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>CHANNEL_CREATE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_CREATE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_UPDATE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_DELETE</description>
        /// </item>
        /// <item>
        /// <description>CHANNEL_PINS_UPDATE</description>
        /// </item>
        /// </list>
        /// </summary>
        DirectMessage = 1 << 12,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>MESSAGE_REACTION_ADD</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE_ALL</description>
        /// </item>
        /// <item>
        /// <description>MESSAGE_REACTION_REMOVE_EMOJI</description>
        /// </item>
        /// </list>
        /// </summary>
        DirectMessageReactions = 1 << 13,
        /// <summary>
        /// Subscribes to the following intents from the server:
        /// <list type="bullet">
        /// <item>
        /// <description>TYPING_START</description>
        /// </item>
        /// </list>
        /// </summary>
        DirectMessageTyping = 1 << 14
    }
}

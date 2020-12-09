namespace HeeHooPeanut.Discord.Api.Gateway.Events
{
    /// <summary>
    /// Contains constant strings for possible gateway events sent from the server
    /// </summary>
    public class GatewayEventNames
    {
        /// <summary>
        /// Contains the initial state information
        /// </summary>
        public const string Ready = "READY";

        /// <summary>
        /// Response to "Resume"
        /// </summary>
        public const string Resumed = "RESUMED";

        /// <summary>
        /// Server is going away, client should reconnect to gateway and resume
        /// </summary>
        public const string Reconnect = "RECONNECT";

        /// <summary>
        /// Failure response to Identity or Resume or invalid active session
        /// </summary>
        public const string InvalidSession  = "INVALID_SESSION";

        /// <summary>
        /// New channel created
        /// </summary>
        public const string ChannelCreate  = "CHANNEL_CREATE";

        /// <summary>
        /// Channel was updated
        /// </summary>
        public const string ChannelUpdate  = "CHANNEL_UPDATE";

        /// <summary>
        /// Channel was deleted
        /// </summary>
        public const string ChannelDelete  = "CHANNEL_DELETE";

        /// <summary>
        /// Message was pinned or unpinned
        /// </summary>
        public const string ChannelPinsUpdate  = "CHANNEL_PINS_UPDATE";

        /// <summary>
        /// Lazy-load for unavailable guild, guild became available, or user joined a new guild
        /// </summary>
        public const string GuildCreate  = "GUILD_CREATE";

        /// <summary>
        /// Guild was updated
        /// </summary>
        public const string GuildUpdate  = "GUILD_UPDATE";

        /// <summary>
        /// Guild became unavailable, or user left/was removed from a guild
        /// </summary>
        public const string GuildDelete  = "GUILD_DELETE";

        /// <summary>
        /// User was banned from a guild
        /// </summary>
        public const string GuildBanAdd  = "GUILD_BAN_ADD";

        /// <summary>
        /// User was unbanned from a guild
        /// </summary>
        public const string GuildBanRemove  = "GUILD_BAN_REMOVE";

        /// <summary>
        /// Guild emojis were updated
        /// </summary>
        public const string GuildEmojisUpdate  = "GUILD_EMOJI_UPDATE";

        /// <summary>
        /// Guild integration was updated
        /// </summary>
        public const string GuildIntegrationsUpdate  = "GUILD_INTEGRATIONS_UPDATE";

        /// <summary>
        /// New user joined a guild
        /// </summary>
        public const string GuildMemberAdd  = "GUILD_MEMBER_ADD";

        /// <summary>
        /// User was removed from a guild
        /// </summary>
        public const string GuildMemberRemove  = "GUILD_MEMBER_REMOVE";

        /// <summary>
        /// Guild member was updated
        /// </summary>
        public const string GuildMemberUpdate  = "GUILD_MEMBER_UPDATE";

        /// <summary>
        /// Response to Request Guild Members
        /// </summary>
        public const string GuildMembersChunk  = "GUILD_MEMBERS_CHUNK";

        /// <summary>
        /// Guild role was created
        /// </summary>
        public const string GuildRoleCreate  = "GUILD_ROLE_CREATE";

        /// <summary>
        /// Guild role was updated
        /// </summary>
        public const string GuildRoleUpdate  = "GUILD_ROLE_UPDATE";

        /// <summary>
        /// Guild role was deleted
        /// </summary>
        public const string GuildRoleDelete  = "GUILD_ROLE_DELETE";
        
        /// <summary>
        /// Invite to a channel was created
        /// </summary>
        public const string InviteCreate  = "INVITE_CREATED";

        /// <summary>
        /// Invite to a channel was deleted
        /// </summary>
        public const string InviteDeleted  = "INVITE_DELETED";

        /// <summary>
        /// Message was created
        /// </summary>
        public const string MessageCreate  = "MESSAGE_CREATE";

        /// <summary>
        /// Message was updated
        /// </summary>
        public const string MessageUpdate  = "MESSAGE_UPDATE";

        /// <summary>
        /// Message was deleted
        /// </summary>
        public const string MessageDelete  = "MESSAGE_DELETE";

        /// <summary>
        /// Multiple messages were deleted at once
        /// </summary>
        public const string MessageDeleteBulk  = "MESSAGE_DELETE_BULK";

        /// <summary>
        /// User reacted to a message
        /// </summary>
        public const string MessageReactionAdd  = "MESSAGE_REACTION_ADD";

        /// <summary>
        /// User removed a reaction from a message
        /// </summary>
        public const string MessageReactionRemove  = "MESSAGE_REACTION_REMOVE";

        /// <summary>
        /// All reactions were explicitly removed from a message
        /// </summary>
        public const string MessageReactionRemoveAll  = "MESSAGE_REACTION_REMOVE_ALL";

        /// <summary>
        /// All reactions for a given emoji were explicitly removed from a message
        /// </summary>
        public const string MessageReactionRemoveEmoji  = "MESSAGE_REACTION_REMOVE_EMOJI";

        /// <summary>
        /// User was updated
        /// </summary>
        public const string PresenceUpdate  = "PRESENCE_UPDATE";

        /// <summary>
        /// User started typing in a channel
        /// </summary>
        public const string TypingStart  = "TYPING_START";

        /// <summary>
        /// Properties about the user changed
        /// </summary>
        public const string UserUpdate  = "USER_UPDATE";

        /// <summary>
        /// Someone joined, left, or moved a voice channel
        /// </summary>
        public const string VoiceStateUpdate  = "VOICE_STATE_UPDATE";

        /// <summary>
        /// Guild's voice server was updated
        /// </summary>
        public const string VoiceServerUpdate  = "VOICE_SERVER_UPDATE";

        /// <summary>
        /// Guild channel webhook was created, updated, or deleted
        /// </summary>
        public const string WebhooksUpdate  = "WEBHOOKS_UPDATE";
    }
}

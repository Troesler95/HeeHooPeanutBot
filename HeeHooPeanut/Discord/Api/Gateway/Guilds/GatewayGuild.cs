using HeeHooPeanut.Discord.Api.Gateway.Guilds.Channels;
using HeeHooPeanut.Discord.Api.Gateway.Users;
using HeeHooPeanut.Discord.Api.Gateway.Voice;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Represents a Guild (server) in Discord
    /// </summary>
    public class GatewayGuild : IGatewayDataMessage
    {
        /// <summary>
        /// Guild Id in snowflake format
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Guild name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Hash correlating to the guild's icon
        /// </summary>
        [JsonPropertyName("icon")]
        public string IconHash { get; set; }

        /// <summary>
        /// Hash correlating to the guild's splash
        /// </summary>
        [JsonPropertyName("splash")]
        public string SplashHash { get; set; }

        /// <summary>
        /// Hash correlating to the guild's discovery splash
        /// </summary>
        /// <remarks>Only present for guilds with the </remarks>
        [JsonPropertyName("discovery_splash")]
        public string DiscoverySplashHash { get; set; }

        /// <summary>
        /// True if the user is the owner of the guild
        /// </summary>
        /// <remarks>Only sent when this guild is associated with a user</remarks>
        [JsonPropertyName("owner")]
        public bool? Owner { get; set; }

        /// <summary>
        /// The snowflake id of the owner of this guild
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Total permissions for the user in the guild
        /// </summary>
        /// <remarks>Only sent when this guild is associated with a user</remarks>
        [JsonPropertyName("permissions")]
        public int? Permissions { get; set; }

        /// <summary>
        /// Voice region id for the guild
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Id of away from keyboard channel
        /// </summary>
        [JsonPropertyName("afk_channel_id")]
        public string AfkChannelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("afk_timeout")]
        public int AfkTimeout { get; set; }

        /// <summary>
        /// Verification level required for the guild
        /// </summary>
        [JsonPropertyName("verification_level")]
        public GuildVerificationLevel VerificationLevel { get; set; }

        /// <summary>
        /// Default message notifications level
        /// </summary>
        [JsonPropertyName("default_message_notifications")]
        public GuildMessageNotificationLevel DefaultMessageNotificationsLevel { get; set; }

        /// <summary>
        /// The guild's default explicit content filter
        /// </summary>
        [JsonPropertyName("explicit_content_filter")]
        public GuildExplicitContentFilterLevel ExplicitContentFilterLevel { get; set; }

        /// <summary>
        /// Roles in the guild
        /// </summary>
        [JsonPropertyName("roles")]
        public GuildRole[] Roles { get; set; }

        /// <summary>
        /// Custom guild emojis
        /// </summary>
        [JsonPropertyName("emojis")]
        public GuildEmoji[] Emojis { get; set; }

        /// <summary>
        /// Enabled guild features
        /// </summary>
        /// <remarks>Check against <see cref="GuildFeatures"/> constants</remarks>
        [JsonPropertyName("features")]
        public string[] Features { get; set; }

        /// <summary>
        /// Required MFA level for the guild
        /// </summary>
        [JsonPropertyName("mfa_level")]
        public GuildMultifactorAuthenticationLevel MfaLevel { get; set; }

        /// <summary>
        /// Application id of the guild creator if it is bot-created
        /// </summary>
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// True if the server widget is enabled
        /// </summary>
        [JsonPropertyName("widget_enabled")]
        public bool? WidgetEnabled { get; set; }

        /// <summary>
        /// The channel id that the widget will generate an invite to
        /// </summary>
        /// <remarks>null if set to no invite</remarks>
        [JsonPropertyName("widget_channel_id")]
        public string WidgetChannelIdSnowflake { get; set; }

        /// <summary>
        /// The id of the channel where guild notices such as welcome messages and boost events are posted
        /// </summary>
        [JsonPropertyName("system_channel_id")]
        public string SystemChannelIdSnowflake { get; set; }

        /// <summary>
        /// System channel flags
        /// </summary>
        [JsonPropertyName("system_channel_flags")]
        public GuildSystemChannelFlags SystemChannelFlags { get; set; }

        /// <summary>
        /// The id of the channel where guilds with the "PUBLIC" feature can display
        /// rules and/or guildines
        /// </summary>
        [JsonPropertyName("rules_channel_id")]
        public string RulesChannelIdSnowflake { get; set; }

        /// <summary>
        /// When this guild was joined at
        /// </summary>
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// True if this is considered a large guild
        /// </summary>
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("large")]
        public bool? LargeGuild { get; set; }

        /// <summary>
        /// True if this guild is unavailable due to an outage
        /// </summary
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("unavailable")]
        public bool? Unavailable { get; set; }

        /// <summary>
        /// Total number of members in this guild
        /// </summary>
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("member_count")]
        public int? MemberCount { get; set; }

        /// <summary>
        /// States of members currently in voice channels
        /// </summary>
        /// <remarks>
        /// This field is only sent within the "GUILD_CREATE" event. <para/>
        /// Lacks the <see cref="GatewayVoiceState.GuildIdSnowflake"/> key
        /// </remarks>
        [JsonPropertyName("voice_states")]
        public GatewayVoiceState[] VoiceStates { get; set; }

        /// <summary>
        /// Users in the guild
        /// </summary>
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("members")]
        public GuildMember[] Members { get; set; }

        /// <summary>
        /// Channels in the guild
        /// </summary>
        /// <remarks>This field is only sent within the "GUILD_CREATE" event </remarks>
        [JsonPropertyName("channels")]
        public GuildChannel[] Channels { get; set; }

        /// <summary>
        /// Presences of the members in the guild
        /// </summary>
        /// <remarks>
        /// This field is only sent within the "GUILD_CREATE" event <para/>
        /// Will only include non-offline members if the size is greater than <see cref="LargeThreshold"/>
        /// </remarks>
        [JsonPropertyName("presences")]
        public GuildPresenceUpdate[] Presences { get; set; }

        /// <summary>
        /// The maximum number of presences for the guild
        /// </summary>
        /// <remarks>Default value is in effect (25000) if this value is null</remarks>
        [JsonPropertyName("max_presences")]
        public int? MaxPresences { get; set; }

        /// <summary>
        /// The maximum number of members for the guild
        /// </summary>
        [JsonPropertyName("max_members")]
        public int? MaxMembers { get; set; }

        /// <summary>
        /// The vanity url code for the guild
        /// </summary>
        [JsonPropertyName("vanity_url_code")]
        public string VanityUrlCode { get; set; }

        /// <summary>
        /// The description for the guild if the guild is discoverable
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Banner hash
        /// </summary>
        [JsonPropertyName("banner")]
        public string BannerHash { get; set; }

        /// <summary>
        /// The server's boost level
        /// </summary>
        [JsonPropertyName("premium_tier")]
        public GuildPremiumTierType PremiumTier { get; set; }

        /// <summary>
        /// The number of boosts this guild currently has
        /// </summary>
        [JsonPropertyName("premium_subscription_count")]
        public int? PremiumSubscriptionCount { get; set; }

        /// <summary>
        /// The preferred locale of a guild with the "PUBLIC" feature
        /// </summary>
        /// <remarks>Defaults to "en-US"</remarks>
        [JsonPropertyName("preferred_locale")]
        public string PreferredLocale { get; set; }

        /// <summary>
        /// The id of the channel where admins and moderators of  guilds with the "PUBLIC" feature receive notices from Discord
        /// </summary>
        [JsonPropertyName("public_updates_channel_id")]
        public string PublicUpdatesChannelId { get; set; }

        /// <summary>
        /// The maximum amount of users in a video channel
        /// </summary>
        [JsonPropertyName("max_video_channel_users")]
        public int? MaxVideoChannelUsers { get; set; }

        /// <summary>
        /// Approximate number of members in this guild
        /// </summary>
        /// <remarks>Returned from the GET /guild/[id] endpoint when "with_counts" is true</remarks>
        [JsonPropertyName("approximate_member_count")]
        public int? ApproximateMemberCount { get; set; }

        /// <summary>
        /// Approximate number of non-offline members in this guild
        /// </summary>
        /// <remarks>returned from the GET /guild/[id] endpoint when with_counts is true</remarks>
        [JsonPropertyName("approximate_presence_count")]
        public int? ApproximatePresenceCount { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayGuild() { }
    }
}

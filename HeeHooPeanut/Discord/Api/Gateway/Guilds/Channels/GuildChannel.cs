using HeeHooPeanut.Discord.Api.Gateway.Users;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds.Channels
{
    /// <summary>
    /// Represents a guild or DM channel within Discord
    /// </summary>
    public class GuildChannel : IGatewayDataMessage
    {
        /// <summary>
        /// The id of this channel
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// The type of channel
        /// </summary>
        [JsonPropertyName("type")]
        public GuildChannelType Type { get; set; }

        /// <summary>
        /// The id of the guild
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// Sorting position of the channel
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// Explicit permission overwrites for members and roles
        /// </summary>
        [JsonPropertyName("permission_overwrites")]
        public ChannelPermissionsOverwrite[] PermissionOverwrites { get; set; }

        /// <summary>
        /// The name of the channel
        /// </summary>
        /// <remarks>Must be between 2 and 100 characters</remarks>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A channel topic
        /// </summary>
        /// <remarks>Must be between 0 and 1024 characters</remarks>
        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// Whether the channel is nsfw
        /// </summary>
        [JsonPropertyName("nsfw")]
        public bool? Nsfw { get; set; }

        /// <summary>
        /// The id of the last message sent in this channel
        /// </summary>
        /// <remarks>May not point to an existing or valid message</remarks>
        [JsonPropertyName("last_message_id")]
        public string LastMessageId { get; set; }

        /// <summary>
        /// The bitrate (in bits) of the voice channel
        /// </summary>
        [JsonPropertyName("bitrate")]
        public int? Bitrate { get; set; }

        /// <summary>
        /// The user limit of the voice channel
        /// </summary>
        [JsonPropertyName("user_limit")]
        public int? UserLimit { get; set; }

        /// <summary>
        /// Amount of seconds a user has to wait before sending another message (0-21600)
        /// </summary>
        /// <remarks>Bots and users with the permission 'manage_messages' or 'manage_channel' are unaffected</remarks>
        [JsonPropertyName("rate_limit_per_user")]
        public int? RateLimitPerUser { get; set; }

        /// <summary>
        /// The recipients of the direct message
        /// </summary>
        [JsonPropertyName("recipients")]
        public GatewayUser[] Recipients { get; set; }

        /// <summary>
        /// Icon hash for this channel
        /// </summary>
        [JsonPropertyName("icon")]
        public string IconHash { get; set; }

        /// <summary>
        /// Id of the direct message creator
        /// </summary>
        [JsonPropertyName("owner_id")]
        public string OwnerIdSnowflake { get; set; }

        /// <summary>
        /// Application id of the group DM creator if it is bot-created
        /// </summary>
        [JsonPropertyName("application_id")]
        public string ApplicationIdSnowflake { get; set; }

        /// <summary>
        /// Id of the parent category for a channel
        /// </summary>
        /// <remarks>Each parent category can contain up to 50 channels</remarks>
        [JsonPropertyName("parent_id")]
        public string ParentIdSnowflake { get; set; }

        /// <summary>
        /// When the last pinned message was pinned
        /// </summary>
        [JsonPropertyName("last_pin_timestamp")]
        public DateTime? LastPinTimestamp { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuildChannel() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="idSnowflake">the id of this channel</param>
        /// <param name="type">the type of channel</param>
        /// <param name="guildId">the id of the guild</param>
        /// <param name="position">sorting position of the channel</param>
        /// <param name="permissionOverwrites">explicit permission overwrites for members and roles</param>
        /// <param name="name">the name of the channel (2-100 characters)param>
        /// <param name="topic">the channel topic (0-1024 characters)param>
        /// <param name="nsfw">whether the channel is nsfw</param>
        /// <param name="lastMessageId">the id of the last message sent in this channel</param>
        /// <param name="bitrate">the bitrate (in bits) of the voice channel</param>
        /// <param name="userLimit">the user limit of the voice channel</param>
        /// <param name="rateLimitPerUser">amount of seconds a user has to wait before sending another message</param>
        /// <param name="recipients">the recipients of the DM</param>
        /// <param name="iconHash">icon hashparam>
        /// <param name="ownerIdSnowflake">id of the DM creator</param>
        /// <param name="applicationIdSnowflake">application id of the group DM creator if it is bot-created</param>
        /// <param name="parentIdSnowflake">id of the parent category for a channel</param>
        /// <param name="lastPinTimestamp">when the last pinned message was pinned</param>
        public GuildChannel(string idSnowflake, GuildChannelType type, string guildId, int? position, ChannelPermissionsOverwrite[] permissionOverwrites, string name, string topic, bool? nsfw, string lastMessageId, 
            int? bitrate, int? userLimit, int? rateLimitPerUser, GatewayUser[] recipients, string iconHash, string ownerIdSnowflake, string applicationIdSnowflake, string parentIdSnowflake, DateTime? lastPinTimestamp)
        {
            IdSnowflake = idSnowflake;
            Type = type;
            GuildId = guildId;
            Position = position;
            PermissionOverwrites = permissionOverwrites;
            Name = name;
            Topic = topic;
            Nsfw = nsfw;
            LastMessageId = lastMessageId;
            Bitrate = bitrate;
            UserLimit = userLimit;
            RateLimitPerUser = rateLimitPerUser;
            Recipients = recipients;
            IconHash = iconHash;
            OwnerIdSnowflake = ownerIdSnowflake;
            ApplicationIdSnowflake = applicationIdSnowflake;
            ParentIdSnowflake = parentIdSnowflake;
            LastPinTimestamp = lastPinTimestamp;
        }
    }
}

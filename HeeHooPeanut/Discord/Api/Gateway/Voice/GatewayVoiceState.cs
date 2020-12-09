using HeeHooPeanut.Discord.Api.Gateway.Guilds;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Voice
{
    /// <summary>
    /// Represents a user's voice connection status
    /// </summary>
    public class GatewayVoiceState : IGatewayDataMessage
    {
        /// <summary>
        /// The guild id this voice state is for
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildIdSnowflake { get; set; }

        /// <summary>
        /// The channel id this user is connected to
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelIdSnowflake { get; set; }

        /// <summary>
        /// The user id this voice state is for
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserIdSnowflake { get; set; }

        /// <summary>
        /// The guild member this voice state is for
        /// </summary>
        [JsonPropertyName("member")]
        public GuildMember Member { get; set; }

        /// <summary>
        /// The session id for this voice state
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Whether this user is deafened by the server 
        /// </summary>
        [JsonPropertyName("deaf")]
        public bool Deaf { get; set; }
        
        /// <summary>
        /// Whether this user is muted by the server
        /// </summary>
        [JsonPropertyName("mute")]
        public bool Mute { get; set; }

        /// <summary>
        /// Whether this user is locally deafened
        /// </summary>
        [JsonPropertyName("self_deaf")]
        public bool SelfDeaf { get; set; }

        /// <summary>
        /// Whether this user is locally muted
        /// </summary>
        [JsonPropertyName("self_mute")]
        public bool SelfMute { get; set; }

        /// <summary>
        /// Whether this user is streaming using "Go Live"
        /// </summary>
        [JsonPropertyName("self_stream")]
        public bool? SelfStream { get; set; }

        /// <summary>
        /// Whether this user's camera is enabled
        /// </summary>
        [JsonPropertyName("self_video")]
        public bool SelfVideo { get; set; }

        /// <summary>
        /// Whether this user is muted by the current user
        /// </summary>
        [JsonPropertyName("suppress")]
        public bool Suppress { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayVoiceState() { }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="guildIdSnowflake">the guild id this voice state is for</param>
        /// <param name="channelIdSnowflake">the channel id this user is connected to</param>
        /// <param name="userIdSnowflake">the user id this voice state is for</param>
        /// <param name="member">the guild member this voice state is for</param>
        /// <param name="sessionId">the session id for this voice state</param>
        /// <param name="deaf">whether this user is deafened by the server</param>
        /// <param name="mute">whether this user is muted by the server</param>
        /// <param name="selfDeaf">whether this user is locally deafened</param>
        /// <param name="selfMute">whether this user is locally muted</param>
        /// <param name="selfStream">whether this user is streaming using "Go Live"</param>
        /// <param name="selfVideo">whether this user's camera is enabled</param>
        /// <param name="suppress">whether this user is muted by the current user</param>
        public GatewayVoiceState(string guildIdSnowflake, string channelIdSnowflake, string userIdSnowflake, GuildMember member, string sessionId, 
            bool deaf, bool mute, bool selfDeaf, bool selfMute, bool? selfStream, bool selfVideo, bool suppress)
        {
            GuildIdSnowflake = guildIdSnowflake;
            ChannelIdSnowflake = channelIdSnowflake;
            UserIdSnowflake = userIdSnowflake;
            Member = member;
            SessionId = sessionId;
            Deaf = deaf;
            Mute = mute;
            SelfDeaf = selfDeaf;
            SelfMute = selfMute;
            SelfStream = selfStream;
            SelfVideo = selfVideo;
            Suppress = suppress;
        }
    }
}

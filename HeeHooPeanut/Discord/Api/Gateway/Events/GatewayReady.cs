using HeeHooPeanut.Discord.Api.Gateway.Guilds;
using HeeHooPeanut.Discord.Api.Gateway.Users;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Events
{
    /// <summary>
    /// Enumerates the possible values of the gateway
    /// </summary>
    public enum GatewayVersion
    {
        /// <summary>
        /// Version 6 of the API
        /// </summary>
        V6 = 6,
        /// <summary>
        /// Version 5 of the API
        /// </summary>
        V5 = 5,
        /// <summary>
        /// Version 4 of the API
        /// </summary>
        V4 = 4
    }

    /// <summary>
    /// Dispatched to the client after the initial handshake with the gateway.
    /// </summary>
    public class GatewayReady : IGatewayDataMessage
    {
        /// <summary>
        /// Current version of the gateway
        /// </summary>
        [JsonPropertyName("v")]
        public GatewayVersion Version { get; set; }

        /// <summary>
        /// Information about the user including email
        /// </summary>
        [JsonPropertyName("user")]
        public GatewayUser User { get; set; }

        /// <summary>
        /// Empty Array
        /// </summary>
        public Array PrivateChannels { get; set; }

        /// <summary>
        /// Relationships with the user
        /// </summary>
        [JsonPropertyName("relationships")]
        public GatewayRelationship[] Relationships { get; set; }

        /// <summary>
        /// Collection of guilds this user is a part of
        /// </summary>
        /// <remarks>These will initially be invalid, and later sent with a <see cref="GuildCreate"/> event</remarks>
        [JsonPropertyName("guilds")]
        public GatewayGuild[] Guilds { get; set; }

        /// <summary>
        /// Used for resuming connections
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// The shard information associated with this session, if sent when identifying
        /// </summary>
        [JsonPropertyName("shard")]
        public int[] Shard { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        public GatewayReady() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="version"></param>
        /// <param name="user"></param>
        /// <param name="privChannels"></param>
        /// <param name="guilds"></param>
        /// <param name="sessionId"></param>
        /// <param name="shard"></param>
        public GatewayReady(GatewayVersion version, GatewayUser user, Array privChannels, 
            GatewayGuild[] guilds, string sessionId, int[] shard = null)
        {
            Version = version;
            User = user;
            PrivateChannels = privChannels;
            Guilds = guilds;
            SessionId = sessionId;
            Shard = shard;
        }
    }
}

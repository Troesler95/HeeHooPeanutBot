using HeeHooPeanut.Discord.Api.Gateway.Events;
using HeeHooPeanut.Discord.Api.Gateway.Intents;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Identify
{
    /// <summary>
    /// Used to trigger the initial handshake with the gateway
    /// </summary>
    /// https://discord.com/developers/docs/topics/gateway#identify
    public class GatewayIdentify : IGatewayDataMessage
    {
        /// <summary>
        /// Authentication token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Properties for this gateway connection
        /// </summary>
        [JsonPropertyName("properties")]
        public GatewayIdentifyConnectionProperties ConnectionProperties { get; set; }

        /// <summary>
        /// Whether this connection supports compression of packets
        /// </summary>
        /// <remarks>If unset, defaults to false</remarks>
        [JsonPropertyName("compress")]
        public bool? Compress { get; set; }

        /// <summary>
        /// Value between 50 and 250, total number of members where the gateway will
        /// stop sending offline members in the guild member list
        /// </summary>
        /// <remarks>If unset, defaults to 50</remarks>
        [JsonPropertyName("large_threshold")]
        public int? LargeThreshold 
        { 
            get => _largeThreshold;
            set => _largeThreshold = (50 <= value && value <= 250) ? value : throw new ArgumentOutOfRangeException();
        }
        private int? _largeThreshold;

        /// <summary>
        /// Used for Guild Sharding
        /// </summary>
        /// <remarks>Should contain at most two values. (shard_id, num_shards)</remarks>
        /// https://discord.com/developers/docs/topics/gateway#sharding
        [JsonPropertyName("shard")]
        public IList<int> Shard { get; set; }

        /// <summary>
        /// Presence structure for initial presence information
        /// </summary>
        [JsonPropertyName("presence")]
        public GatewayUpdateStatus Presence { get; set; }

        /// <summary>
        /// Enables dispatching of guild subscription events (presence and typing events)
        /// </summary>
        /// <remarks>If unset, defaults to true.</remarks>
        [JsonPropertyName("guild_subscriptions")]
        public bool? GuildSubscriptions { get; set; }

        // TODO: come back to this when figuring out intents
        // https://discord.com/developers/docs/topics/gateway#gateway-intents
        /// <summary>
        /// The gateway intents you wish to receive
        /// </summary>
        [JsonPropertyName("intents")]
        public GatewayIntents? Intents { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayIdentify() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="connProps">Properties for this gateway connection</param>
        /// <param name="compress">Whether this connection supports compression of packets</param>
        /// <param name="largeThresh">value between 50 and 250, total number of members where the gateway will stop sending offline members in the guild member list</param>
        /// <param name="shard">Used for guild sharding. Should contain at most two values. (shard_id, num_shards)</param>
        /// <param name="presence">Presence structure for initial presence information</param>
        /// <param name="guildSubs">Enables dispatching of guild subscription events (presence and typing events)</param>
        /// <param name="intents">The gateway intents to receive</param>
        public GatewayIdentify(string token, GatewayIdentifyConnectionProperties connProps,
            bool? compress = null, int? largeThresh = null, 
            IList<int> shard = null, GatewayUpdateStatus presence = null, 
            bool? guildSubs = null, GatewayIntents? intents = null)
        {
            Token = token;
            ConnectionProperties = connProps;
            Compress = compress;
            LargeThreshold = largeThresh;
            Shard = shard;
            Presence = presence;
            GuildSubscriptions = guildSubs;
            Intents = intents;
        }
    }
}

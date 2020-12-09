using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.REST
{
    /// <summary>
    /// Represents the response returned from the Discord Gateway request REST Api
    /// </summary>
    public class BotGatewayHttpResponse
    {
        /// <summary>
        /// The WSS URL that can be used for connecting to the gateway
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The recommended number of shards to use when connecting
        /// </summary>
        [JsonPropertyName("shards")]
        public int Shards { get; set; }

        /// <summary>
        /// Information on the current session start limit
        /// </summary>
        [JsonPropertyName("session_start_limit")]
        public SessionStartLimit StartLimit { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="uri">The WSS URL that can be used for connecting to the gateway</param>
        /// <param name="shards">The recommended number of shards to use when connecting</param>
        /// <param name="startLimit">Information on the current session start limit</param>
        public BotGatewayHttpResponse(Uri url, int shards, SessionStartLimit startLimit)
        {
            Url = url;
            Shards = shards;
            StartLimit = startLimit;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BotGatewayHttpResponse() { }
    }
}

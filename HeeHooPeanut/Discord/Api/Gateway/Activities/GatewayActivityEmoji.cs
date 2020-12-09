using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Defines an emoji used for a gateway activity
    /// </summary>
    public class GatewayActivityEmoji
    {
        /// <summary>
        /// The name of the emoji
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The id of the emoji
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// Whether the emoji is animated
        /// </summary>
        [JsonPropertyName("animated")]
        public bool? Animated { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivityEmoji() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name">the name of the emoji</param>
        /// <param name="idSnowflake">the id of the emoji</param>
        /// <param name="animated">whether this emoji is animated</param>
        public GatewayActivityEmoji(string name, string idSnowflake, bool? animated)
        {
            Name = name;
            IdSnowflake = idSnowflake;
            Animated = animated;
        }
    }
}

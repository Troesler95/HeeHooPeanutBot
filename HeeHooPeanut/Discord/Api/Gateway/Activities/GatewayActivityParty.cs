using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Represents an activity party
    /// </summary>
    public class GatewayActivityParty
    {
        /// <summary>
        /// The id of the party
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Used to show the party's current and maximum size
        /// </summary>
        /// <remarks>Array of two integers [current_size, max_size]</remarks>
        [JsonPropertyName("size")]
        public int[] Size { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivityParty() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">The id of the party</param>
        /// <param name="size">Used to show the party's current and maximum size</param>
        public GatewayActivityParty(string id, int[] size)
        {
            Id = id;
            Size = size;
        }
    }
}

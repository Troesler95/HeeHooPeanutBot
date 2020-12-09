using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Defintes an activity time interval
    /// </summary>
    public class GatewayActivityTimestamp
    {
        /// <summary>
        /// unix time (in milliseconds) of when the activity started
        /// </summary>
        [JsonPropertyName("start")]
        public int? Start { get; set; }

        /// <summary>
        /// unix time (in milliseconds) of when the activity ends
        /// </summary>
        [JsonPropertyName("end")]
        public int? End { get; set; }
    }
}

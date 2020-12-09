using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.REST
{
    /// <summary>
    /// A session start limit object returned by the Discord REST Api
    /// </summary>
    public class SessionStartLimit
    {
        /// <summary>
        /// The total number of session starts the current user is allowed
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// The remaining number of session starts the current user is allowed
        /// </summary>
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        /// <summary>
        /// The number of milliseconds after which the limit resets
        /// </summary>
        [JsonPropertyName("rest_after")]
        public int ResetAfter { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="total">Total number of session starts the current user is allowed</param>
        /// <param name="remaining">The remaining number of session starts the current user is allowed</param>
        /// <param name="resetAfter">The number of milliseconds after which the limit resets</param>
        public SessionStartLimit(int total, int remaining, int resetAfter)
        {
            Total = total;
            Remaining = remaining;
            ResetAfter = resetAfter;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SessionStartLimit() { }
    }
}

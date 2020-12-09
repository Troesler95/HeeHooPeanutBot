using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Defines secrets associated with a <see cref="GatewayActivity"/>
    /// </summary>
    /// <remarks>Used for rich presence joining and spectating</remarks>
    public class GatewayActivitySecrets
    {
        /// <summary>
        /// The secret for joining a party
        /// </summary>
        [JsonPropertyName("join")]
        public string Join { get; set; }

        /// <summary>
        /// The secret for spectating a game
        /// </summary>
        [JsonPropertyName("spectate")]
        public string Spectate { get; set; }

        /// <summary>
        /// The secret for a specific instanced match
        /// </summary>
        [JsonPropertyName("match")]
        public string Match { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivitySecrets() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="join">the secret for joining a party</param>
        /// <param name="spectate">the secret for spectating a game</param>
        /// <param name="match">the secret for a specific instanced match</param>
        public GatewayActivitySecrets(string join, string spectate, string match)
        {
            Join = join;
            Spectate = spectate;
            Match = match;
        }
    }
}

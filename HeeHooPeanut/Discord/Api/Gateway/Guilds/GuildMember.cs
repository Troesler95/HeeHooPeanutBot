using HeeHooPeanut.Discord.Api.Gateway.Users;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    public class GuildMember
    {
        /// <summary>
        /// The user this guild member represents
        /// </summary>
        /// <remarks>
        /// Not included in the member object attached 
        /// to MESSAGE_CREATE and MESSAGE_UPDATE gateway events
        /// </remarks>
        [JsonPropertyName("user")]
        public GatewayUser User { get; set; }

        /// <summary>
        /// The users guild nickname
        /// </summary>
        /// <remarks>null if no nickname set</remarks>
        [JsonPropertyName("nick")]
        public string Nickname { get; set; }

        /// <summary>
        /// Array of role object id snowflakes
        /// </summary>
        [JsonPropertyName("roles")]
        public string[] RoleIds { get; set; }

        /// <summary>
        /// When the user joined the guild
        /// </summary>
        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// When the user started boosting the guild
        /// </summary>
        [JsonPropertyName("premium_since")]
        public DateTime? PremiumSince { get; set; }

        /// <summary>
        /// Whether the user is deafened in voice channels
        /// </summary>
        [JsonPropertyName("deaf")]
        public bool Deaf { get; set; }

        /// <summary>
        /// Whether the user is muted in voice channels
        /// </summary>
        [JsonPropertyName("mute")]
        public bool Mute { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuildMember() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="user">the user this guild member represents</param>
        /// <param name="nick">this users guild nickname</param>
        /// <param name="roles">array of role object ids</param>
        /// <param name="joinedAt">when the user joined the guild</param>
        /// <param name="premiumSince">when the user started boosting the guild</param>
        /// <param name="deaf">whether the user is deafened in voice channels</param>
        /// <param name="mute">whether the user is muted in voice channels</param>
        public GuildMember(GatewayUser user, string nick, string[] roles, DateTime joinedAt, 
            DateTime? premiumSince = null, bool deaf = false, bool mute = false)
        {
            User = user;
            Nickname = nick;
            RoleIds = roles;
            JoinedAt = joinedAt;
            PremiumSince = premiumSince;
            Deaf = deaf;
            Mute = mute;
        }
    }
}

using HeeHooPeanut.Discord.Api.Gateway.Activities;
using HeeHooPeanut.Discord.Api.Gateway.Events;
using HeeHooPeanut.Discord.Api.Gateway.Users;
using System;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// A user's current status on a Guild
    /// </summary>
    /// <remarks>If using Gateway Intents, the 'GUILD_PRESENCES' intent must be specified to receive presence update events</remarks>
    public class GuildPresenceUpdate
    {
        /// <summary>
        /// The user presence is being updated for
        /// </summary>
        [JsonPropertyName("user")]
        public GatewayUser User { get; set; }

        /// <summary>
        /// Roles this user is in
        /// </summary>
        [JsonPropertyName("roles")]
        public string[] Roles { get; set; }

        /// <summary>
        /// Null, or the user's current activity
        /// </summary>
        [JsonPropertyName("game")]
        public GatewayActivity Game { get; set; }

        /// <summary>
        /// Id of the guild
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildId { get; set; }

        /// <summary>
        /// The status of this user
        /// </summary>
        /// <remarks>Valid options are string values for <see cref="GatewayStatusTypes"/></remarks>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// User's current activities
        /// </summary>
        [JsonPropertyName("activities")]
        public GatewayActivity[] Activities { get; set; }

        /// <summary>
        /// User's platform-dependent status
        /// </summary>
        [JsonPropertyName("client_status")]
        public GatewayActivityClientStatus ClientStatus { get; set; }

        /// <summary>
        /// When the user started boosting the guild
        /// </summary>
        [JsonPropertyName("premium_since")]
        public DateTime? PremiumSince { get; set; }

        /// <summary>
        /// This user's guild nickname (if one is set)
        /// </summary>
        [JsonPropertyName("nick")]
        public string Nickname { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuildPresenceUpdate() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="user">the user presence is being updated for</param>
        /// <param name="roles">roles this user is in</param>
        /// <param name="game">null, or the user's current activity</param>
        /// <param name="guildId">id of the guild</param>
        /// <param name="status">either "idle", "dnd", "online", or "offline"</param>
        /// <param name="activities">user's current activities</param>
        /// <param name="clientStatus">user's platform-dependent status</param>
        /// <param name="premiumSince">when the user started boosting the guild</param>
        /// <param name="nickname">this users guild nickname (if one is set)</param>
        public GuildPresenceUpdate(GatewayUser user, string[] roles, GatewayActivity game, string guildId, string status, 
            GatewayActivity[] activities, GatewayActivityClientStatus clientStatus, DateTime? premiumSince, string nickname)
        {
            User = user;
            Roles = roles;
            Game = game;
            GuildId = guildId;
            Status = status;
            Activities = activities;
            ClientStatus = clientStatus;
            PremiumSince = premiumSince;
            Nickname = nickname;
        }
    }
}

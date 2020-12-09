using System;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Events
{
    /// <summary>
    /// Possible status types
    /// </summary>
    public enum GatewayStatusTypes
    {
        Online,
        Dnd,
        Idle,
        Invisible,
        Offline
    }

    /// <summary>
    /// Sent by the client to indicate a presence or status update
    /// </summary>
    /// https://discord.com/developers/docs/topics/gateway#update-status
    public class GatewayUpdateStatus
    {
        /// <summary>
        /// Unix time of when the client went idle, or null if the client is not idle
        /// </summary>
        [JsonPropertyName("since")]
        public int Since { get; set; }

        /// <summary>
        /// The user's new activity (optional)
        /// </summary>
        [JsonPropertyName("game")]
        public GatewayActivity Game { get; set; }

        /// <summary>
        /// The user's updated status
        /// </summary>
        [JsonPropertyName("status")]
        public GatewayStatusTypes Status { get; set; }

        /// <summary>
        /// Whether or not the client is AFK
        /// </summary>
        [JsonPropertyName("afk")]
        public bool AwayFromKeyboard { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayUpdateStatus() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="since">Unix time of when the client when idle, or null if the client is not idle</param>
        /// <param name="status">The user's updated status</param>
        /// <param name="afk">Whether or not the client is AFK</param>
        /// <param name="activity">The user's new activity</param>
        public GatewayUpdateStatus(int since, GatewayStatusTypes status, bool afk, GatewayActivity activity = null)
        {
            Since = since;
            Game = activity;
            Status = status;
            AwayFromKeyboard = afk;
        }
    }
}

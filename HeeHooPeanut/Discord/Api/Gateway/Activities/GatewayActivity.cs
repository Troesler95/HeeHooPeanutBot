using HeeHooPeanut.Discord.Api.Gateway.Activities;
using HeeHooPeanut.Discord.Api.Gateway.Guilds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway
{
    /// <summary>
    /// Enumerates the possible activity types on a <see cref="GatewayActivity"/>
    /// </summary>
    public enum GatewayActivityTypes
    {
        /// <summary>
        /// User is playing the specified game
        /// </summary>
        Game = 0,
        /// <summary>
        /// User is streaming
        /// </summary>
        Streaming = 1,
        /// <summary>
        /// User is listening to something
        /// </summary>
        Listening = 2,
        /// <summary>
        /// {emoji}{name}
        /// </summary>
        Custom = 4
    }

    /// <summary>
    /// Describes an activity in Discord
    /// </summary>
    /// <remarks>Bots are only able to send Name, Type, and optionally Url.</remarks>
    /// https://discord.com/developers/docs/topics/gateway#activity-object
    public class GatewayActivity
    {
        /// <summary>
        /// The Activity's name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of activity being performed
        /// </summary>
        [JsonPropertyName("type")]
        public GatewayActivityTypes Type { get; set; }

        /// <summary>
        /// Optional URL field. Only used if Type is Streaming.
        /// </summary>
        /// <remarks>The streaming type currently only supports Twitch and YouTube. Only https://twitch.tv/ and https://youtube.com/ urls will work.</remarks>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Unix timestamp of when the activity was added to the user's session
        /// </summary>
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        /// <summary>
        /// Unix timestamps for start/or end of the game
        /// </summary>
        [JsonPropertyName("timestamps")]
        public GatewayActivityTimestamp[] Timestamps { get; set; }

        /// <summary>
        /// Application id for the game
        /// </summary>
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// What the player is currently doing
        /// </summary>
        [JsonPropertyName("details")]
        public string Details { get; set; }

        /// <summary>
        /// The user's current party status
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// The emoji used for a custom status
        /// </summary>
        [JsonPropertyName("emoji")]
        public GatewayActivityEmoji Emoji { get; set; } 

        /// <summary>
        /// Information for the current party of the player
        /// </summary>
        [JsonPropertyName("party")]
        public GatewayActivityParty Party { get; set; }

        /// <summary>
        /// Secrets for Rich Presence joining and spectating
        /// </summary>
        [JsonPropertyName("secrets")]
        public GatewayActivitySecrets Secrets { get; set; }

        /// <summary>
        /// Whether or not the activity is an instanced game session
        /// </summary>
        [JsonPropertyName("instance")]
        public bool? Instance { get; set; }

        /// <summary>
        /// Describes what the payload includes
        /// </summary>
        [JsonPropertyName("flags")]
        public GatewayActivityFlags Flags { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivity() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name">Name of activity</param>
        /// <param name="type">Type of activity being performed</param>
        /// <param name="url">Optional url of the activity</param>
        public GatewayActivity(string name, GatewayActivityTypes type, Uri url)
        {
            Name = name;
            Type = type;
            Url = url;
        }
    }
}

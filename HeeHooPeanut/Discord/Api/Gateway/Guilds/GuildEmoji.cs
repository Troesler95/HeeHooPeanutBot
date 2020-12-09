using HeeHooPeanut.Discord.Api.Gateway.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Defines a custom emoji in use on the guild
    /// </summary>
    public class GuildEmoji
    {
        /// <summary>
        /// Emoji id
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// Emoji name
        /// </summary>
        /// <remarks>Can be null only in reaction emoji objects</remarks>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Roles this emoji is whitelisted to
        /// </summary>
        [JsonPropertyName("roles")]
        public GuildRole[] Roles { get; set; }

        /// <summary>
        /// User that created this emoji
        /// </summary>
        [JsonPropertyName("user")]
        public GatewayUser User { get; set; }

        /// <summary>
        /// Whether this emoji must be wrapped in colons
        /// </summary>
        [JsonPropertyName("required_colons")]
        public bool? RequireColons { get; set; }

        /// <summary>
        /// Whether this emoji is managed
        /// </summary>
        [JsonPropertyName("managed")]
        public bool? Managed { get; set; }

        /// <summary>
        /// Whether this emoji is animated
        /// </summary>
        [JsonPropertyName("animated")]
        public bool? Animated { get; set; }

        /// <summary>
        /// Whether this emoji can be used
        /// </summary>
        /// <remarks>May be false due to loss of Server Boosts</remarks>
        [JsonPropertyName("available")]
        public bool? Available { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuildEmoji() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">Emoji id</param>
        /// <param name="name">Emoji name</param>
        /// <param name="roles">Roles this emoji is whitelisted to</param>
        /// <param name="user">User that created this emoji</param>
        /// <param name="requireColons">Whether this emoji must be wrapped in colons</param>
        /// <param name="managed">Whether this emoji is managed</param>
        /// <param name="animated">Whether this emoji is animated</param>
        /// <param name="available">Whether this emoji can be used</param>
        public GuildEmoji(string id, string name, GuildRole[] roles, GatewayUser user, 
            bool? requireColons, bool? managed, bool? animated, bool? available)
        {
            IdSnowflake = id;
            Name = name;
            Roles = roles;
            User = user;
            RequireColons = requireColons;
            Managed = managed;
            Animated = animated;
            Available = available;
        }
    }
}

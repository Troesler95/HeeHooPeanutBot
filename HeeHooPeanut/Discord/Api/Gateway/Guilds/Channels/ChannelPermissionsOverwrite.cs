using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds.Channels
{
    /// <summary>
    /// Constant string values for channel permissions overwirte objects
    /// </summary>
    public class ChannelPermissionsOverwriteTypes
    {
        /// <summary>
        /// This overwite is for a role
        /// </summary>
        public const string Role = "role";
        /// <summary>
        /// This overwrite is for a member of a guild
        /// </summary>
        public const string Member = "member";
    }

    /// <summary>
    /// Overwite object for channel permissions
    /// </summary>
    public class ChannelPermissionsOverwrite
    {
        /// <summary>
        /// Role or user id
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// Type to overwrite permissions for
        /// </summary>
        /// <remarks>Either 'role' or 'member'</remarks>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        // TODO: figure out permissions allow and deny fields
        /// <summary>
        /// Legacy permissions bit set
        /// </summary>
        [JsonPropertyName("allow")]
        public int Allow { get; set; }

        // TODO: figure out permissions allow and deny fields
        /// <summary>
        /// Legacy permissions bit set
        /// </summary>
        [JsonPropertyName("deny")]
        public int Deny { get; set; }

        /// <summary>
        /// Permissions bit set
        /// </summary>
        [JsonPropertyName("allow_new")]
        public string AllowNew { get; set; }

        /// <summary>
        /// Permissions bit set
        /// </summary>
        [JsonPropertyName("deny_new")]
        public string DenyNew { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="idSnowflake">Role or user id</param>
        /// <param name="type">Type to overwrite permissions for</param>
        /// <param name="allow">Permissions bit set</param>
        /// <param name="deny">Permissions bit set</param>
        /// <param name="allowNew">Permissions bit set</param>
        /// <param name="denyNew">Permissions bit set</param>
        public ChannelPermissionsOverwrite(string idSnowflake, string type, int allow, int deny,
            string allowNew, string denyNew)
        {
            IdSnowflake = idSnowflake;
            Type = type;
            Allow = allow;
            Deny = deny;
            AllowNew = allowNew;
            DenyNew = denyNew;
        }
    }
}

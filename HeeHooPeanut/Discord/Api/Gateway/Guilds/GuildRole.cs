using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    public class GuildRole
    {
        /// <summary>
        /// Role id
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Integer representation of hexadecimal color code
        /// </summary>
        [JsonPropertyName("color")]
        public int Color { get; set; }

        /// <summary>
        /// If this role is pinned in the user listings
        /// </summary>
        [JsonPropertyName("hoist")]
        public bool Hoist { get; set; }

        /// <summary>
        /// Position of this role
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Legacy permission bit set
        /// </summary>
        [JsonPropertyName("permissions")]
        public int Permissions { get; set; }

        /// <summary>
        /// Permission bit set
        /// </summary>
        [JsonPropertyName("permissions_new")]
        public string PermissionsNew { get; set; }

        /// <summary>
        /// Whether this role is managed by an integration
        /// </summary>
        [JsonPropertyName("managed")]
        public bool Managed { get; set; }

        /// <summary>
        /// Whether this role is mentionable
        /// </summary>
        [JsonPropertyName("mentionable")]
        public bool Mentionable { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuildRole() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">Role id</param>
        /// <param name="name">Role name</param>
        /// <param name="color">Integer representation of hexadecimal color code</param>
        /// <param name="hoist">If this role is pinned in the user listings</param>
        /// <param name="pos">Position of this role</param>
        /// <param name="permiss">Legacy permission bit set</param>
        /// <param name="permissNew">Permission bit set</param>
        /// <param name="managed">Whether this role is managed by an integration</param>
        /// <param name="mentionable">Whether this role is mentionable</param>
        public GuildRole(string id, string name, int color, bool hoist, int pos, 
            int permiss, string permissNew, bool managed, bool mentionable)
        {
            IdSnowflake = id;
            Name = name;
            Color = color;
            Hoist = hoist;
            Position = pos;
            Permissions = permiss;
            PermissionsNew = permissNew;
            Managed = managed;
            Mentionable = mentionable;
        }
    }
}

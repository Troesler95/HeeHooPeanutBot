using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Users
{
    public class GatewayUser
    {
        /// <summary>
        /// The user's id
        /// </summary>
        [JsonPropertyName("id")]
        public string IdSnowflake { get; set; }

        /// <summary>
        /// The user's username, not unique across the platform
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// The user's 4-digit discord-tag
        /// </summary>
        [JsonPropertyName("discriminator")]
        public string Discriminator { get; set; }

        /// <summary>
        /// The user's avatar hash
        /// </summary>
        [JsonPropertyName("avatar")]
        public string AvatarHash { get; set; }

        /// <summary>
        /// Whether the user belongs to an OAuth2 application
        /// </summary>
        [JsonPropertyName("bot")]
        public bool Bot { get; set; }

        /// <summary>
        /// Whether the user is an Official Discord System user (part of the urgent message system)
        /// </summary>
        [JsonPropertyName("system")]
        public bool System { get; set; }

        /// <summary>
        /// Whether the user has two factor enabled on their account
        /// </summary>
        [JsonPropertyName("mfa_enabled")]
        public bool MultiFactorAuthEnabled { get; set; }

        /// <summary>
        /// The user's chosen language option
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Whether the email on this account has been verified
        /// </summary>
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        /// <summary>
        /// The user's email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// The flags on a user's account
        /// </summary>
        [JsonPropertyName("flags")]
        public UserFlags? Flags { get; set; }

        /// <summary>
        /// The type of subscription on a user's account
        /// </summary>
        [JsonPropertyName("premium_type")]
        public UserPremiumType? PremiumType { get; set; }

        /// <summary>
        /// The public flags on a user's account
        /// </summary>
        [JsonPropertyName("public_flags")]
        public UserFlags? PublicFlags { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayUser() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="username">The user's username, not unique across the platform</param>
        /// <param name="discrim">The user's 4-digit discord-tag</param>
        /// <param name="avatar">The user's avatar hash</param>
        /// <param name="bot">Whether the user belongs to an OAuth2 application</param>
        /// <param name="system">Whether the user is an Official Discord System user (part of the urgent message system)</param>
        /// <param name="mfaEnabled">Whether the user has two factor enabled on their account</param>
        /// <param name="locale">The user's chosen language option</param>
        /// <param name="verified">Whether the email on this account has been verified</param>
        /// <param name="email">The user's email</param>
        /// <param name="flags">The flags on a user's account</param>
        /// <param name="premType">The type of subscription on a user's account</param>
        /// <param name="publicFlags">The public flags on a user's account</param>
        public GatewayUser(string id, string username, string discrim, string avatar,
            bool bot = false, bool system = false, bool mfaEnabled = false, string locale = "en",
            bool verified = false, string email = null, UserFlags? flags = null, UserPremiumType? premType = null,
            UserFlags? publicFlags = null)
        {
            IdSnowflake = id;
            Username = username;
            Discriminator = discrim;
            AvatarHash = avatar;
            Bot = bot;
            System = system;
            MultiFactorAuthEnabled = mfaEnabled;
            Locale = locale;
            Verified = verified;
            Email = email;
            Flags = flags;
            PremiumType = premType;
            PublicFlags = publicFlags;
        }
    }
}

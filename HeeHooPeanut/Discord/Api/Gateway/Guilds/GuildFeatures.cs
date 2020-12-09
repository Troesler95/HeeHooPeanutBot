using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    public class GuildFeatures
    {
        /// <summary>
        /// Guild has access to set an invite splash background
        /// </summary>
        public const string InviteSplash = "INVITE_SPLASH";

        /// <summary>
        /// Guild has access to set 384kbps bitrate in voice (previously VIP voice servers)
        /// </summary>
        public const string VipRegions = "VIP_REGIONS";

        /// <summary>
        /// Guild has access to set a vanity URL
        /// </summary>
        public const string VanityUrl = "VANITY_URL";

        /// <summary>
        /// Guild is verified
        /// </summary>
        public const string Verified = "VERIFIED";

        /// <summary>
        /// Guild is partnered
        /// </summary>
        public const string Partnered = "PARTNERED";

        /// <summary>
        /// Guild is public
        /// </summary>
        public const string Public = "PUBLIC";

        /// <summary>
        /// Guild has access to user commerce features (create store channels)
        /// </summary>
        public const string Commerce = "COMMERCE";

        /// <summary>
        /// Guild has access to create news channels
        /// </summary>
        public const string News = "NEWS";

        /// <summary>
        /// Guild is able to be discovered in the directory
        /// </summary>
        public const string Discoverable = "DISCOVERABLE";

        /// <summary>
        /// Guild is able to be featured in the directory
        /// </summary>
        public const string Featurable = "FEATURABLE";

        /// <summary>
        /// Guild has access to set an animated guild icon
        /// </summary>
        public const string AnimatedIcon = "ANIMATED_ICON";

        /// <summary>
        /// Guild has access to set a guild banner image
        /// </summary>
        public const string Banner = "BANNER";

        /// <summary>
        /// Guild cannot be public
        /// </summary>
        public const string PublicDisabled = "PUBLIC_DISABLED";

        /// <summary>
        /// Guild has enabled the welcome screen
        /// </summary>
        public const string WelcomeScreenEnabled = "WELCOME_SCREEN_ENABLED";
    }
}

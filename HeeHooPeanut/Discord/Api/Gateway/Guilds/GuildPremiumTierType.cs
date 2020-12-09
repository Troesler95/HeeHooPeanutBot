using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Enumerates the possible premium tiers for a server (server boost level)
    /// </summary>
    public enum GuildPremiumTierType
    {
        /// <summary>
        /// No premium tier
        /// </summary>
        None = 0,
        /// <summary>
        /// Tier 1
        /// </summary>
        Tier1 = 1,
        /// <summary>
        /// Tier 2
        /// </summary>
        Tier2 = 2,
        /// <summary>
        /// Tier 3
        /// </summary>
        Tier3 = 3
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Enumerates the possible MFA levels on a guild
    /// </summary>
    public enum GuildMultifactorAuthenticationLevel
    {
        /// <summary>
        /// No MFA requirement
        /// </summary>
        None = 0,
        /// <summary>
        /// MFA is required for this server
        /// </summary>
        Elevated = 1
    }
}

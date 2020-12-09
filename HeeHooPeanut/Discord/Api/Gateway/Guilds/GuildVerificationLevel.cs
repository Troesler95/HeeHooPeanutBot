using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Enumerates the possible verification levels on a guild
    /// </summary>
    public enum GuildVerificationLevel
    {

        /// <summary>
        /// Unrestricted
        /// </summary>
        None = 0,
        /// <summary>
        /// Must have verified email on account
        /// </summary>
        Low = 1,
        /// <summary>
        /// Must be reistered on Discord for longer than 5 minutes
        /// </summary>
        Medium = 2,
        /// <summary>
        /// Must be a member of the server for longer than 10 minutes
        /// </summary>
        /// <remarks>(╯°□°）╯︵ ┻━┻ </remarks>
        High = 3,
        /// <summary>
        /// Must have a verified phone number
        /// </summary>
        /// <remarks>┻━┻ ミヽ(ಠ 益 ಠ)ﾉ彡 ┻━┻</remarks>
        VeryHigh = 4
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Possible flags for the guild's system channel
    /// </summary>
    [Flags]
    public enum GuildSystemChannelFlags
    {
        /// <summary>
        /// Suppress member join notifications
        /// </summary>
        SuppressJoinNotifications = 1 << 0,
        /// <summary>
        /// Suppress server boost notifications
        /// </summary>
        SupressPremiumSubscriptions = 1 << 1
    }
}

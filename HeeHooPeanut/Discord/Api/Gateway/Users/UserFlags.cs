using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Users
{
    /// <summary>
    /// Enumerates the possible flags on a user account
    /// </summary>
    [Flags]    
    public enum UserFlags
    {
        None = 0,
        DiscordEmployee = 1 << 0,
        DiscordPartner = 1 << 1,
        HypeSquadEvents = 1 << 2,
        BugHunterLevel1 = 1 << 3,
        HouseBravery = 1 << 6,
        HouseBrilliance = 1 << 7,
        HouseBalance = 1 << 8,
        EarlySupporter = 1 << 9,
        TeamUser = 1 << 10,
        System = 1 << 12,
        BugHunterLevel2 = 1 << 14,
        VerifiedBot = 1 << 16,
        VerifiedBotDeveloper = 1 << 17
    }
}

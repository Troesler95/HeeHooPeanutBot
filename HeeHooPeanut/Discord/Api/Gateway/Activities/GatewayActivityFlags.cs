using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Possible flags on a <see cref="GatewayActivity"/>
    /// </summary>
    [Flags]
    public enum GatewayActivityFlags
    {
        Instance = 1 << 0,
        Join = 1 << 1,
        Spectate = 1 << 2,
        JoinRequest = 1 << 3,
        Sync = 1 << 4,
        Play = 1 << 5
    }
}

namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Enumerates the possilbe message notification levels on a guild
    /// </summary>
    public enum GuildMessageNotificationLevel
    {
        /// <summary>
        /// User is notified of all messages
        /// </summary>
        AllMessages = 0,
        /// <summary>
        /// User is notified only when @mentioned
        /// </summary>
        OnlyMentions = 1
    }
}

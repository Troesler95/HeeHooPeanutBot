namespace HeeHooPeanut.Discord.Api.Gateway.Guilds
{
    /// <summary>
    /// Enumerates the possible explicit content filters
    /// </summary>
    public enum GuildExplicitContentFilterLevel
    {
        /// <summary>
        /// No filter
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// Filter explicit content for members without roles
        /// </summary>
        MembersWithoutRoles = 1,
        /// <summary>
        /// Filter explicit content for all members
        /// </summary>
        AllMembers = 2
    }
}

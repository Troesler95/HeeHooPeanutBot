using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api.Gateway.Users
{
    /// <summary>
    /// Possible relationships between two Discord users
    /// </summary>
    public enum GatewayRelationshipType
    {
        /// <summary>
        /// The user is a friend
        /// </summary>
        Friend = 1,
        /// <summary>
        /// The user is blocked
        /// </summary>
        Blocked = 2,
        /// <summary>
        /// The user has requested a friend request
        /// </summary>
        IncomingPending = 3,
        /// <summary>
        /// The user has a pending friend request
        /// </summary>
        OutgoingPending = 4
    }

    /// <summary>
    /// Defines the relationship between a user and another user
    /// </summary>
    public class GatewayRelationship
    {
        /// <summary>
        /// Id of this relationship
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user the relationship is with
        /// </summary>
        public GatewayUser User { get; set; }

        /// <summary>
        /// Relationship with the user
        /// </summary>
        public GatewayRelationshipType RelationshipType { get; set; }
    }
}

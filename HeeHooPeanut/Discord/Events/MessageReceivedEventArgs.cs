using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Events
{
    /// <summary>
    /// Event arguments containing the message received from the Discord gateway
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Message received
        /// </summary>
        public GatewayPayload Message { get; }
        
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="message">Message to include in the event</param>
        public MessageReceivedEventArgs(GatewayPayload message)
        {
            Message = message;
        }
    }
}

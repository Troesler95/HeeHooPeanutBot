using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord.Api
{
    /// <summary>
    /// Provides enumerations for the possible Discord Opcodes in response messages
    /// </summary>
    public static class OpCodes
    {
        /// <summary>
        /// Defines possible opcodes from a Discord gateway
        /// </summary>
        public enum Gateway
        {
            /// <summary>
            /// An event was dispatched by the gateway
            /// </summary>
            Dispatch = 0,

            /// <summary>
            /// Fired periodically by the client to keep the connection alive
            /// </summary>
            Heartbeat = 1,

            /// <summary>
            /// Starts a new session during the initial handshake
            /// </summary>
            Identify = 2,

            /// <summary>
            /// Update the client's presence
            /// </summary>
            PresenceUpdate = 3,

            /// <summary>
            /// Used to join/leave or move between voice channels
            /// </summary>
            VoiceStateUpdate = 4,

            /// <summary>
            /// Resume a previous session that was disconnected
            /// </summary>
            Resume = 6,

            /// <summary>
            /// Signifies you should reconnect to the gateway and resume immediately
            /// </summary>
            Reconnect = 7,

            /// <summary>
            /// Request information about offline guild members in a large guild
            /// </summary>
            RequestGuildMembers = 8,

            /// <summary>
            /// The session has been invalidated. <br />
            /// You should reconnect and identify/resume accordingly.
            /// </summary>
            InvalidSession = 9,

            /// <summary>
            /// Sent immediately after connecting.
            /// </summary>
            Hello = 10,

            /// <summary>
            /// Sent in response to receiving a heartbeat to acknowledge that it has been received.
            /// </summary>
            HeartbeatACK = 11
        }

        /// <summary>
        /// Opcodes sent by the voice gateway
        /// </summary>
        public enum Voice
        {
            /// <summary>
            /// Begin a voice websocket connection
            /// </summary>
            Identify = 0,

            /// <summary>
            /// Select the voice protocol
            /// </summary>
            SelectProtocol = 1,

            /// <summary>
            /// Complete the websocket handshake
            /// </summary>
            Ready = 2,

            /// <summary>
            /// Keep the websocket connection alive
            /// </summary>
            Heartbeat = 3,

            /// <summary>
            /// Describe the session
            /// </summary>
            SessionDescription = 4,

            /// <summary>
            /// Indicate which users are speaking
            /// </summary>
            Speaking = 5,

            /// <summary>
            /// Sent to acknowledge a received client heartbeat
            /// </summary>
            HeartbeatACK = 6,

            /// <summary>
            /// Resume a connection
            /// </summary>
            Resume = 7,

            /// <summary>
            /// Time to wait between sending heartbeats in milleseconds
            /// </summary>
            Hello = 8,
            
            /// <summary>
            /// Acknowledge a successful session resume
            /// </summary>
            Resumed = 9,

            /// <summary>
            /// A client has disconnected from the voice channel
            /// </summary>
            ClientDisconnect = 13
        }
    }
}

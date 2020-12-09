using HeeHooPeanut.Discord.Api.JsonConverters;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway
{
    /// <summary>
    /// Represents a gateway payload object to send or be received by the Discord Gateway
    /// </summary>
    [JsonConverter(typeof(GatewayPayloadJsonConverter))] 
    public class GatewayPayload : IMessage
    {
        /// <summary>
        /// Opcode for the payload
        /// </summary>
        [JsonPropertyName("op")]
        public OpCodes.Gateway Code { get; set; }

        /// <summary>
        /// Event data
        /// </summary>
        // [JsonConverter(typeof(GatewayPayloadDataConverter))]
        [JsonPropertyName("d")]
        public IGatewayDataMessage Data { get; set; }
        
        /// <summary>
        /// Sequence number. <para />
        /// Used for resuming sessions and heartbeats.
        /// </summary>
        [JsonPropertyName("s")]
        public int? SequenceNumber { get; set; }

        /// <summary>
        /// The event name for this payload
        /// </summary>
        [JsonPropertyName("t")]
        public string EventName { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="code">OpCode for this payload</param>
        /// <param name="data">Data for this payload</param>
        /// <param name="seqNum">Sequence number used for resuming sessions and heartbeats</param>
        /// <param name="eventName">the event name for this payload</param>
        // public GatewayPayload(OpCodes.Gateway code, IGatewayDataMessage data = null, int? seqNum = null, string eventName = null)
        public GatewayPayload(OpCodes.Gateway code, IGatewayDataMessage data = null, int? seqNum = null, string eventName = null)
        {
            Code = code;
            Data = data;
            SequenceNumber = seqNum;
            EventName = eventName;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayPayload() { }
    }
}

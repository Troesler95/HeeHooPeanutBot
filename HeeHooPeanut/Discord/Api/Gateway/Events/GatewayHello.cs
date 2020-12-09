using HeeHooPeanut.Discord.Interfaces.Messages;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Events

{
    /// <summary>
    /// Hello message sent by gateway defining the interval to use for the heartbeat message
    /// </summary>
    class GatewayHello : IGatewayDataMessage
    {
        /// <summary>
        /// Interval between heartbeat messages
        /// </summary>
        [JsonPropertyName("heartbeat_interval")]
        public int HeartbeatInterval { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="interval">Interval to use</param>
        public GatewayHello(int interval)
            => HeartbeatInterval = interval;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayHello() { }
    }
}

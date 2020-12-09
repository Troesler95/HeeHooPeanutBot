using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Identify
{
    /// <summary>
    /// Connection properties for the GatewayIdentify object
    /// </summary>
    public class GatewayIdentifyConnectionProperties
    {
        /// <summary>
        /// Operating System this connection is from
        /// </summary>
        [JsonPropertyName("$os")]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Browser the connection is from (should just be library name!)
        /// </summary>
        [JsonPropertyName("$browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Device the connection is from (should just be library name!)
        /// </summary>
        [JsonPropertyName("$device")]
        public string Device { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GatewayIdentifyConnectionProperties() { }

        public GatewayIdentifyConnectionProperties(string os, string browser, string device) 
        {
            OperatingSystem = os;
            Browser = browser;
            Device = device;
        }
    }
}

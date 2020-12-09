using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Defines a client status on various types of clients for a <see cref="GatewayActivity"/>
    /// </summary>
    public class GatewayActivityClientStatus
    {
        /// <summary>
        /// the user's status set for an active desktop (Windows, Linux, Mac) application session
        /// </summary>
        [JsonPropertyName("desktop")]
        public string Desktop { get; set; }

        /// <summary>
        /// the user's status set for an active mobile (iOS, Android) application session
        /// </summary>
        [JsonPropertyName("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// the user's status set for an active web (browser, bot account) application session
        /// </summary>
        [JsonPropertyName("web")]
        public string Web { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivityClientStatus() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="desktop">the user's status set for an active desktop (Windows, Linux, Mac) application session</param>
        /// <param name="mobile">the user's status set for an active mobile (iOS, Android) application session</param>
        /// <param name="web">the user's status set for an active web (browser, bot account) application session</param>
        public GatewayActivityClientStatus(string desktop, string mobile, string web)
        {
            Desktop = desktop;
            Mobile = mobile;
            Web = web;
        }
    }
}

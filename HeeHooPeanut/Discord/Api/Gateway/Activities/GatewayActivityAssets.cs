using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.Gateway.Activities
{
    /// <summary>
    /// Defines assests associated with a <see cref="GatewayActivity"/>
    /// </summary>
    public class GatewayActivityAssets
    {
        /// <summary>
        /// The id for the large asset of the activity, usually a snowflake
        /// </summary>
        [JsonPropertyName("large_image")]
        public string LargeImage { get; set; }

        /// <summary>
        /// Text displayed when hovering over the large image of the activity
        /// </summary>
        [JsonPropertyName("large_text")]
        public string LargeText { get; set; }

        /// <summary>
        /// The id for a small asset of the activity, usually a snowflake
        /// </summary>
        [JsonPropertyName("small_image")]
        public string SmallImage { get; set; }

        /// <summary>
        /// Text displayed when hovering over the small image of the activity
        /// </summary>
        [JsonPropertyName("small_text")]
        public string SmallText { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayActivityAssets() { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="largeImage">the id for a large asset of the activity</param>
        /// <param name="largeText">text displayed when hovering over the large image of the activity</param>
        /// <param name="smallImage">the id for a small asset of the activity</param>
        /// <param name="smallText">text displayed when hovering over the small image of the activity</param>
        public GatewayActivityAssets(string largeImage, string largeText, string smallImage, string smallText)
        {
            LargeImage = largeImage;
            LargeText = largeText;
            SmallImage = smallImage;
            SmallText = smallText;
        }
    }
}

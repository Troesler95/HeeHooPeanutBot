using System;
using System.Collections.Generic;
using System.Text;

namespace HeeHooPeanut.Discord
{
    public class BotAuth
    {
        public string BotToken { get; set; }

        public string ClientId { get; set; }

        public override string ToString()
        {
            return $"\"BotAuth\":{{\n  \"BotToken\": {BotToken}\n  \"ClientId\": {ClientId}\n}}";
        }
    }
}

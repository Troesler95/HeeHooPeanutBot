using HeeHooPeanut.Discord.Api;
using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Api.Gateway.Identify;
using HeeHooPeanut.Discord.Api.Gateway.Intents;
using HeeHooPeanut.Discord.Interfaces;
using HeeHooPeanut.Discord.Interfaces.Server;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace HeeHooPeanut.Discord
{
    public class PeanutBotService : IBotService, IDisposable
    {
        private readonly BotAuth botAuth;

        private readonly IDiscordClient discordClient;

        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="client"></param>
        public PeanutBotService(IOptions<BotAuth> options, IDiscordClient client)
        {
            botAuth = options?.Value ?? new BotAuth { BotToken = string.Empty, ClientId = string.Empty };
            discordClient = client;
        }

        public Task Run()
        {
            return Task.Run(async () =>
            {
                await discordClient.StartAsync();
                if (discordClient.Connected)
                {
                    Console.WriteLine("Successfully started connection to discord gateway.");
                    await IdentifyBot();
                }

                // TODO: what are our exit conditions?
                while(true)
                {

                }
            });
        }

        private async Task IdentifyBot()
        {
            GatewayIdentify identifyMessage = new GatewayIdentify
            {
                Token = botAuth?.BotToken ?? string.Empty,
                ConnectionProperties = new GatewayIdentifyConnectionProperties("potassium", "monkey", "banana"),
                Intents = GatewayIntents.DirectMessage | GatewayIntents.DirectMessageTyping | GatewayIntents.Guilds
            };
            GatewayPayload payload = new GatewayPayload
            {
                Code = OpCodes.Gateway.Identify,
                Data = identifyMessage
            };

            await discordClient.SendMessageAsync(payload);
        }

        #region IDisposable Implementation
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    discordClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~PeanutBot()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

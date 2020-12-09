using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Api.REST;
using HeeHooPeanut.Discord.Interfaces.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeeHooPeanut.Discord.Client
{
    /// <summary>
    /// Rest client class for interracting with Discord's REST ApiS
    /// </summary>
    public class DiscordRestClient : IDiscordRestClient, IDisposable
    {
        private HttpClient httpClient = null;
        private readonly BotAuth botAuth = null;

        /// <summary>
        /// Dependency Injection constructor
        /// </summary>
        public DiscordRestClient(IOptions<BotAuth> options)
        {
            botAuth = options?.Value ?? new BotAuth();
            InitializeClient();
        }

        /// <summary>
        /// Gets a gateway from the Discord REST Api to connect to
        /// </summary>
        /// <returns>Gateway response object</returns>
        public async Task<BotGatewayHttpResponse> GetGatewayAsync()
        {
            Console.WriteLine("Requesting gateway URL from Discord...");
            BotGatewayHttpResponse gatewayResponse = null;
            try
            {
                var response = await httpClient.GetAsync(DiscordKnownRestRoutes.GetGatewayBot);

                if (response?.StatusCode == HttpStatusCode.OK)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    gatewayResponse =  await JsonSerializer.DeserializeAsync<BotGatewayHttpResponse>(responseStream);
                }
                // TODO: Handle REST errors
                else
                {
                    Console.WriteLine($"ERR: HttpClient returned with code {response?.StatusCode}. Reason given: {response?.ReasonPhrase}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERR: encounterd an exception getting the gateway.");
                Console.WriteLine($"{ex.Message}\n\r{ex.InnerException}\n\r{ex.StackTrace}");
            }
            return gatewayResponse;
        }

        /// <summary>
        /// Initializes this client with default values
        /// </summary>
        private void InitializeClient()
        {
            if (httpClient == null)
            {
                var handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botAuth.BotToken);
                httpClient.BaseAddress = new Uri(DiscordKnownRestRoutes.BaseUrl);
            }
        }

        #region IDisposable Implementation
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    httpClient?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

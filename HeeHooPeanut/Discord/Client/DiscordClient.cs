using HeeHooPeanut.Discord.Api;
using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Api.Gateway.Events;
using HeeHooPeanut.Discord.Api.Gateway.Identify;
using HeeHooPeanut.Discord.Api.JsonConverters;
using HeeHooPeanut.Discord.Api.REST;
using HeeHooPeanut.Discord.Events;
using HeeHooPeanut.Discord.Interfaces.Client;
using HeeHooPeanut.Discord.Interfaces.Messages;
using HeeHooPeanut.Discord.Interfaces.Server;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HeeHooPeanut.Discord.Client
{
    public class DiscordClient : IDiscordClient
    {
        private readonly ILogger<DiscordClient> Logger;

        private const int SEND_BUFFER_SIZE = 1024 * 4;  // Discord gateway has a maximum of 4kb chunks
        private const int RECV_BUFFER_SIZE = 1024 * 16; // Max chunk size sent by the gateway
        private ClientWebSocket webSocketClient = null;
        private ManualResetEventSlim closeRequestedEvent = new ManualResetEventSlim(true);
        private readonly IDiscordRestClient discordRestClient;
        private readonly BotAuth botAuth;
        private readonly JsonSerializerOptions serializerOptions;
        private readonly JsonSerializerOptions deserializerOptions;

        private readonly object seqLock = new object();
        private int lastSeqNumber = 0;

        private readonly object ackLock = new object();
        private bool ackReceived = false;

        private Task heartbeatThread = null;
        private CancellationTokenSource heartbeatCTS= new CancellationTokenSource();

        private Task receiveProcessThread = null;
        private CancellationTokenSource receiveCTS = new CancellationTokenSource();


        /// <summary>
        /// Whether the client is connected to the Discord Gateway
        /// </summary>
        public bool Connected { get => webSocketClient.State == WebSocketState.Open; }

        /// <summary>
        /// Dependency Injection constructor
        /// </summary>
        /// <param name="options">Configuration options</param>
        /// <param name="restClient">Rest client implementation</param>
        public DiscordClient(IOptions<BotAuth> options, IDiscordRestClient restClient, ILogger<DiscordClient> logger)
        {
            botAuth = options?.Value ?? new BotAuth();
            discordRestClient = restClient;
            Logger = logger;
            webSocketClient = new ClientWebSocket();

            deserializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNameCaseInsensitive = true,
            };
            deserializerOptions.Converters.Add(new GatewayPayloadJsonConverter());
        }

        /// <summary>
        /// Send the given message to the gateway
        /// </summary>
        /// <param name="message">Message to send</param>
        public async Task SendMessageAsync(IMessage message)
        {
            if(message is GatewayPayload)
            {
                await SendMessageAsyncInternal(message as GatewayPayload);
            }
            else
            {
                Logger.LogError("Unsupported message type passed to DiscordClient.SendMessageAsync.");
            }
        }

        /// <summary>
        /// Send the given message to the gateway
        /// </summary>
        /// <param name="message">Message to send</param>
        // TODO: make this more generic
        private async Task SendMessageAsyncInternal(GatewayPayload message, CancellationTokenSource cts = null)
        {
            ArraySegment<byte> buffer = WebSocket.CreateClientBuffer(RECV_BUFFER_SIZE, SEND_BUFFER_SIZE);
            using MemoryStream memStream = new MemoryStream();
            CancellationToken ctoken = cts?.Token ?? new CancellationToken();

            if (message != null)
            {
                await JsonSerializer.SerializeAsync(memStream, message, new JsonSerializerOptions { IgnoreNullValues = true });
                memStream.Seek(0, SeekOrigin.Begin);

                int numChunks = Math.Max((int)memStream.Length / SEND_BUFFER_SIZE, 1);
                int curChunk = 0;
                int totalBytesRead = 0, curBytesRead = 0;
                string sent = string.Empty;

                do
                {
                    curBytesRead = await memStream.ReadAsync(buffer.Array, curChunk * SEND_BUFFER_SIZE, SEND_BUFFER_SIZE, ctoken);
                    await webSocketClient.SendAsync(new ArraySegment<byte>(buffer.Array, 0, curBytesRead), WebSocketMessageType.Text, numChunks == curChunk + 1, ctoken);
                    sent += Encoding.UTF8.GetString(buffer);
                    totalBytesRead += curBytesRead;
                } while (numChunks != ++curChunk);

                if (totalBytesRead != memStream.Length)
                {
                    throw new IOException("Error occurred while sending message. Number of bytes read from stream is less than the total size of the object to send.");
                }

                Logger.LogTrace($"Sent the following message to the gateway:\n{sent}");
            }
        }

        /// <summary>
        /// Start the client by connecting to and completing the handshake with the gateway
        /// </summary>
        public async Task StartAsync()
        {
            await ConnectToGatewayAsync();
            StartReceiveProcessThread();
        }

        private void StartReceiveProcessThread()
        {
            if (receiveProcessThread != null) 
                CancelThreadHelper(receiveProcessThread, ref receiveCTS);

            receiveProcessThread = Task.Run(async () =>
            {
                string incomingMessage = string.Empty;
                ArraySegment<byte> buffer = WebSocket.CreateClientBuffer(RECV_BUFFER_SIZE, SEND_BUFFER_SIZE);

                while (!receiveCTS.IsCancellationRequested)
                {
                    // if close requested after this point, make sure we don't end up in a 
                    // weird state, null references, etc..
                    closeRequestedEvent.Reset();

                    var res = await webSocketClient.ReceiveAsync(buffer, receiveCTS.Token);

                    incomingMessage += Encoding.UTF8.GetString(buffer).Trim('\0');

                    buffer = null;
                    buffer = new ArraySegment<byte>(new byte[SEND_BUFFER_SIZE]);

                    if (res.EndOfMessage && res.MessageType != WebSocketMessageType.Close)
                    {
                        Logger.LogTrace($"Recevied complete message from Gateway: {incomingMessage}");
                        using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(incomingMessage)))
                        {
                            memStream.Position = 0;
                            GatewayPayload payload = await JsonSerializer.DeserializeAsync<GatewayPayload>(memStream, deserializerOptions, receiveCTS.Token);
                            if (payload != null)
                            {
                                HandleMessage(payload);
                            }
                            else
                            {
                                Logger.LogError($"Unable to parse message received from gateway.\n\r{incomingMessage}");
                            }
                        }
                        incomingMessage = string.Empty;
                    }
                    else
                    {
                        ;
                    }
                    closeRequestedEvent.Set();
                }
                incomingMessage = null;
                buffer = null;
            }, receiveCTS.Token);
        }

        private void StartHeartbeatThread(int interval)
        {
            if (heartbeatThread != null)
                CancelThreadHelper(heartbeatThread, ref heartbeatCTS);

            heartbeatThread = Task.Run(async () =>
            {
                GatewayPayload heartbeatMsg = new GatewayPayload
                {
                    Code = OpCodes.Gateway.Heartbeat,
                    SequenceNumber = lastSeqNumber
                };

                while (!heartbeatCTS.IsCancellationRequested)
                {
                    heartbeatMsg.SequenceNumber = lastSeqNumber;
                    await SendMessageAsyncInternal(heartbeatMsg);
                    
                    // reset ack flag after sending heartbeat message
                    lock (ackLock)
                        ackReceived = false;

                    await Task.Delay(interval);
                }
            }, heartbeatCTS.Token);
        }

        private void HandleMessage(GatewayPayload payload)
        {
            lock (seqLock)
            {
                if(payload.SequenceNumber.HasValue && payload.SequenceNumber.Value > 0)
                    lastSeqNumber = payload.SequenceNumber.Value;
            }

            switch(payload.Code)
            {
                case OpCodes.Gateway.Hello:
                    GatewayHello data = payload.Data as GatewayHello;
                    if (data != null)
                    {
                        Logger.LogTrace($"Starting web socket heartbeat with interval {data.HeartbeatInterval}");
                        StartHeartbeatThread(data.HeartbeatInterval);
                    }
                    break;
                case OpCodes.Gateway.HeartbeatACK:
                    // heartbeat acks should be received between heartbeet messages. If not, we have a problem
                    lock (ackLock) 
                        ackReceived = true;
                    break;
                case OpCodes.Gateway.Dispatch:
                    switch (payload.EventName)
                    {
                        case GatewayEventNames.Ready:
                            // TODO: store or alert client with state
                            GatewayReady ready = payload.Data as GatewayReady;

                            break;
                        case GatewayEventNames.GuildCreate:
                            break;
                    }
                    break;
                default:
                    RaiseMessageReceived(payload);
                    break;
            }
        }

        private async Task ConnectToGatewayAsync()
        {
            if (webSocketClient.State != WebSocketState.None && webSocketClient.State != WebSocketState.Closed)
            {
                await CloseWebSocketAsync();
            }

            // TODO: where to handle reconnects?
            var gatewayResponse = await discordRestClient?.GetGatewayAsync();

            Logger.LogTrace($"Connecting to gateway {gatewayResponse?.Url}");

            UriBuilder uriBuilder = new UriBuilder(gatewayResponse?.Url);
            uriBuilder.Query += "v=6&encoding=json";

            CancellationToken ct = new CancellationToken();
            await webSocketClient?.ConnectAsync(uriBuilder.Uri, ct);
        }

        private void CancelThreadHelper(Task toCancel, ref CancellationTokenSource cts)
        {
            if (toCancel != null && cts != null)
            {
                cts.Cancel();
                toCancel.Wait();
                cts.Dispose();
                cts = new CancellationTokenSource();
            }
        }

        private async Task CloseWebSocketAsync()
        {
            // request stop for all asynchronous operations on the web socket client
            receiveCTS.Cancel();
            heartbeatCTS.Cancel();

            // ensure we don't close the connection while processing is happening.
            closeRequestedEvent.Wait();

            // use a separate cancellation token for close async, since the cts above is set to cancel
            var token = new CancellationToken();
            await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close requested by client.", token);

            // get a new CTS that isn't cancelled
            receiveCTS.Dispose();
            heartbeatCTS.Dispose();
            receiveCTS = new CancellationTokenSource();
            heartbeatCTS = new CancellationTokenSource();
        }

        #region Events
        /// <summary>
        /// Event raised when a message is received from the websocket
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Raise the MessageReceived event with the given message
        /// </summary>
        /// <param name="message">Message to include in the event</param>
        protected virtual void RaiseMessageReceived(GatewayPayload message) => MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        #endregion

        #region IDisposable Implementation
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    receiveCTS?.Cancel();
                    heartbeatCTS?.Cancel();
                    webSocketClient?.CloseAsync(WebSocketCloseStatus.NormalClosure, "Shutting down client", new CancellationToken()).Wait();
                    webSocketClient?.Dispose();
                    receiveCTS?.Dispose();
                    heartbeatCTS?.Dispose();
                    closeRequestedEvent?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DiscordClient()
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

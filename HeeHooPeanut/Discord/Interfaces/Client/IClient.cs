using HeeHooPeanut.Discord.Events;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Threading.Tasks;

namespace HeeHooPeanut.Discord.Interfaces
{
    public interface IClient : IDisposable
    {
        /// <summary>
        /// Returns whether this client is properly connected to Discord
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Event fired when a message is received by the client
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        Task StartAsync();

        Task SendMessageAsync(IMessage message);

    }
}

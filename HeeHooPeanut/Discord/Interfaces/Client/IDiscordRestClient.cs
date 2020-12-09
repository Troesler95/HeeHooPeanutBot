using HeeHooPeanut.Discord.Api.REST;
using System.Threading.Tasks;

namespace HeeHooPeanut.Discord.Interfaces.Client
{
    public interface IDiscordRestClient
    {
        Task<BotGatewayHttpResponse> GetGatewayAsync();
    }
}

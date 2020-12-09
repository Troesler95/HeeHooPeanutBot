using System.Threading.Tasks;
using HeeHooPeanut.Discord;
using HeeHooPeanut.Discord.Client;
using HeeHooPeanut.Discord.Interfaces;
using HeeHooPeanut.Discord.Interfaces.Client;
using HeeHooPeanut.Discord.Interfaces.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Extensions.Logging;

namespace HeeHooPeanut
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static async Task Main(string[] args)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddUserSecrets<Program>()
                .Build();

            // TODO: these options should probably just be thrown into
            // either a singleton provider, or an option that is injected into dependencies.
            // kind of depends on how our rest calls will work.
            IServiceCollection services = new ServiceCollection();
            using ServiceProvider serviceProvider = services
                .Configure<BotAuth>(Configuration.GetSection(nameof(BotAuth)))
                .AddOptions()
                .AddSingleton<IBotService, PeanutBotService>()
                .AddTransient<IDiscordClient, DiscordClient>()
                .AddTransient<IDiscordRestClient, DiscordRestClient>()
                .AddLogging(logBuilder =>
                {
                    logBuilder.ClearProviders();
                    logBuilder.SetMinimumLevel(LogLevel.Trace);
                    logBuilder.AddNLog("NLog.config");
                })
                .BuildServiceProvider();

            var botService = serviceProvider.GetService<IBotService>();
            await botService.Run();
        }
    }
}

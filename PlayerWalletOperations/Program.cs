// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace PlayerWalletOperations
{

    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IPlay, Play>();
                    services.AddTransient<IWallet, Wallet>();
                })
                .Build();

            var myService = host.Services.GetRequiredService<IPlay>();
            await myService.RunAsync();

            await host.StopAsync();
        }
    }
}

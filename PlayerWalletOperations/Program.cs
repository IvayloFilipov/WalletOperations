// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace PlayerWalletOperations
{

    class Program
    {
        // This is the entry point of a C# program. It's marked as async to allow use of await (for asynchronous operations).
        static async Task Main(string[] args)
        {
            //This is the beginning of setting up and configuring a .NET application using dependency injection and hosting services. This is commonly used in ASP.NET Core, console apps. 
            // IHost is a central component that manages app startup, services, configuration, and lifetime.
            using IHost host = Host.CreateDefaultBuilder(args)
                // ConfigureServices receives a services collection that you populate with your app's services.
                .ConfigureServices((context, services) =>
                {
                    // Registers services (IPlay, IWallet) into the dependency injection container.
                    services.AddTransient<IPlay, Play>(); // A new instance is provided to every controller (if have sutch) and service
                    services.AddTransient<IWallet, Wallet>();
                })
                // Finalizes the host building. Now you can start resolving services and running the app.
                .Build();

            // Resolves and uses a service (IPlay) from the DI container. Since you registered IPlay with a concrete implementation (Play), it will create and return a Play instance.
            var myService = host.Services.GetRequiredService<IPlay>();
            // Calls an async method RunAsync() on your Play class (must be defined in Play class).
            await myService.RunAsync();

            // Stops the application host. Useful for cleanup, saving data, or shutting down services.
            await host.StopAsync();
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BlazorConduit.Client.Services;
using Fluxor;
using System.Reflection;
using Blazored.LocalStorage;
using BlazorConduit.Client;
using BlazorConduit.Client.Services.Contracts;

namespace BlazorConduit
{
#pragma warning disable RCS1102 // Make class static.
    public class Program
#pragma warning restore RCS1102 // Make class static.
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");


            // Add custom services
            builder.Services.AddHttpClient<IConduitApiService, ConduitApiService>(client =>
                client.BaseAddress = new Uri("https://conduit.productionready.io/api/"));
            builder.Services.TryAddTransient<IStateFacade, StateFacade>();
            builder.Services.TryAddSingleton<IErrorFormattingService, ErrorFormattingService>();
            builder.Services.TryAddTransient<ITokenService, SecurityTokenService>();

            // Add package services
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
                options.UseReduxDevTools();
            });

            await builder.Build().RunAsync();
        }
    }
}

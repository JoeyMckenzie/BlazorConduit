using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BlazorConduit.Services;
using Fluxor;
using System.Reflection;
using Blazored.LocalStorage;

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

            builder.Services.AddTransient(_ => new HttpClient { BaseAddress = new Uri("https://conduit.productionready.io/api/") });

            // Add custom services
            builder.Services.TryAddScoped<ConduitApiService>();
            builder.Services.TryAddScoped<StateFacade>();
            builder.Services.TryAddScoped<ErrorFormattingService>();

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

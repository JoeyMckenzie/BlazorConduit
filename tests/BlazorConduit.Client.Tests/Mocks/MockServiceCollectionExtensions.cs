using System;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorConduit.Client.Tests.Mocks
{
    public static class MockServiceCollectionExtensions
    {
        public static IServiceCollection AddMockNavigationManager(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<NavigationManager, MockNavigationManager>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;

namespace NASADemo.NASAClient
{
    public static class IServiceCollectionExtensions
    {
        public static void AddNASAClient(this IServiceCollection services, string apiKey)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (String.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));

            services.AddSingleton<INASAClient>(serviceProvider => new NASAClient(apiKey));
        }
    }
}
using Auth0.Management;
using Auth0.Management.Infrastructure;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddAuthManagement(this IServiceCollection services, Action<ManagementClientSettings> settings)
        {
            var s = new ManagementClientSettings();
            settings?.Invoke(s);

            return services.AddHttpClient<ManagementClient>(builder => { 
                builder.DefaultRequestHeaders.Add("Authorization", $"Bearer {s.ApiToken}");
                builder.BaseAddress = s.Domain;
            });
        }
    }
}

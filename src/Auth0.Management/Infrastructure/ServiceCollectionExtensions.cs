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

            services.AddSingleton(s);

            return services.AddHttpClient<ManagementClient>(builder => {
                builder.BaseAddress = s.Domain;
            });
        }
    }
}

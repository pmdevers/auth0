using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0.Authentication.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddAuthAuthentication(this IServiceCollection services, Action<AuthenticationClientSettings> settings)
        {
            var s = new AuthenticationClientSettings();
            settings?.Invoke(s);

            ValidateSettings(s);

            services.AddSingleton(s);

            return services.AddHttpClient<AuthenticationClient>(builder => {
                //builder.DefaultRequestHeaders.Add("Authorization", $"Bearer {s.ApiToken}");
                builder.BaseAddress = s.Domain;
            });
        }

        private static void ValidateSettings(AuthenticationClientSettings settings)
        {
            if (settings.ClientSecret == null) throw new ArgumentNullException("ClientSecret");
            if (settings.ClientId == null) throw new ArgumentNullException("ClientId");
            //if (settings.RedirectUrl == null) throw new ArgumentNullException("RedirectUrl");
            if (settings.Domain == null) throw new ArgumentNullException("Domain");
        }
    }
}

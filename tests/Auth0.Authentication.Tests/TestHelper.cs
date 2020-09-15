using System;
using System.Net.Http;
using Auth0.Authentication.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0.Authentication.Tests
{
    public static class TestHelper
    {
        public static AuthenticationClient GetClient(HttpResponseMessage response)
        {
            var services = new ServiceCollection();

            services.AddAuthAuthentication(opt =>
                {
                    opt.ClientId = "Fake client Id";
                    opt.ClientSecret = "Fake client secret";
                    opt.Domain = new Uri("http://fake.auth0.com");
                    opt.Audience = new Uri("http://fake.auth0.com");
                })
                .AddHttpMessageHandler(() => new FakeHttpMessageHandler(response));

            var provider = services.BuildServiceProvider();

            return provider.GetService<AuthenticationClient>();
        }
    }
}

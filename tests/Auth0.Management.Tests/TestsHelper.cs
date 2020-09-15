using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0.Management.Tests
{
    public class TestsHelper
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static ManagementClient GetClient(HttpResponseMessage response)
        {
            var services = new ServiceCollection();
            
            services.AddAuthManagement(opt =>
                {
                    opt.ClientId = "Fake Client Id";
                    opt.ClientSecret = "Fake Secret";
                    opt.Audience = new Uri("http://fake.auth0.com");
                    opt.Domain = new Uri("http://fake.auth0.com");
                })
                .AddHttpMessageHandler(() => new FakeHttpMessageHandler(response));

            var provider = services.BuildServiceProvider();

            return provider.GetService<ManagementClient>();
        }

        public static ManagementClient GetClient(object responseObject, HttpStatusCode statusCode)
        {
            var jsonContent = JsonSerializer.Serialize(responseObject, options);
            var response = new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            return GetClient(response);
        }
    }
}

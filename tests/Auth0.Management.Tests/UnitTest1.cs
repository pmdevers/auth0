using Auth0.Management.Branding.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.Management.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var services = new ServiceCollection();
            var url = new Uri("https://www.google.com");
            services.AddAuthManagement(opt =>
                {
                    opt.ApiToken = "Fake Api Token";
                    opt.Domain = new Uri("http://fake.auth0.com");
                })
                .AddHttpMessageHandler(() => new FakeHttpMessageHandler(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonSerializer.Serialize(new BrandingResponse() { FaviconUrl = url, LogoUrl = url}), Encoding.UTF8,
                            "application/json")
                    }
                ));

            var provider = services.BuildServiceProvider();

            var client = provider.GetService<ManagementClient>();

            var result = await client.Branding.GetAsync();

            Assert.Equal(url, result.LogoUrl);
            Assert.Equal(url, result.FaviconUrl);

        }
    }
}

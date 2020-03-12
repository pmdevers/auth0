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
    public class BrandingApiTests
    {
        [Fact]
        public async Task Get_Branding_OK()
        {
            var url = new Uri("https://www.google.com");
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    "{ \"favicon_url\": \"" + url.ToString() + "\", \"logo_url\": \"" + url.ToString() + "\" }", Encoding.UTF8,
                    "application/json")
            };
            var client = TestsHelper.GetClient(response);

            var result = await client.Branding.GetAsync();

            Assert.Equal(url, result.LogoUrl);
            Assert.Equal(url, result.FaviconUrl);

        }

        [Fact]
        public async Task Get_Branding_BadRequest()
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("Invalid request body. The message will vary depending on the cause.", Encoding.UTF8,
                    "application/text")
            };

            var client = TestsHelper.GetClient(response);

            await Assert.ThrowsAsync<ManagementClientException>(async () => await client.Branding.GetAsync());
        }

    }
}

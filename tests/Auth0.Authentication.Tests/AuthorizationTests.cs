using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Auth0.Authentication.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Auth0.Authentication.Tests
{
    public class AuthorizationTests
    {
        [Fact]
        public async Task GetTokenTest_OK()
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    "{" +
                    "   \"access_token\":\"eyJz93a...k4laUWw\"," +
                    "   \"refresh_token\":\"GEbRxBN...edjnXbL\"," +
                    "   \"id_token\":\"eyJ0XAi...4faeEoQ\", " +
                    "   \"token_type\":\"Bearer\"," +
                    "   \"expires_in\":86400 " +
                    "}"
                    )
            };

            var client = TestHelper.GetClient(response);

            var value = await client.Authorization.GetTokenAsync();

            Assert.Equal("eyJz93a...k4laUWw", value.access_token);
            Assert.Equal("GEbRxBN...edjnXbL", value.refresh_token);
            Assert.Equal("eyJ0XAi...4faeEoQ", value.id_token);
            Assert.Equal("Bearer", value.token_type);
            Assert.Equal(86400, value.expires_in);

        }

        [Fact]
        public async Task GetToken()
        {
            var services = new ServiceCollection();

            services.AddAuthAuthentication(s =>
            {
                s.ClientId = "SNzEII6xnjObhe5T25Zmv52KZErNRCyy";
                s.ClientSecret = "SaTIjvCbrzcyXgaBe2WO-p2BiOz7cEC4f0rRkYf48e4RdoRz9rw8PPYqZVeqNxU6";
                s.Audience = new Uri("https://domivest.eu.auth0.com/api/v2/");
                s.Domain = new Uri("https://domivest.eu.auth0.com");
            });

            var provider = services.BuildServiceProvider();

            var client = provider.GetService<AuthenticationClient>();
            
            var token = await client.Authorization.GetTokenAsync();


        }
    }
}

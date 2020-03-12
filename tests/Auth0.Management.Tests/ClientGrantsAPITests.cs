using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Auth0.Management.ClientGrants.Models;

using Xunit;

namespace Auth0.Management.Tests
{
    public class ClientGrantsApiTests
    {
        [Fact]
        public async Task Get_Client_Grants_OK()
        {
            var response = new[]
            {
                new ClientGrantsResponse()
                {
                    Id = Guid.NewGuid().ToString(),
                    ClientId = Guid.NewGuid().ToString(),
                    Audience = Guid.NewGuid().ToString(),
                    Scope = new[]
                    {
                        Guid.NewGuid().ToString(),
                    }
                }
            };

            var client = TestsHelper.GetClient(response, HttpStatusCode.OK);
            var result = await client.ClientGrants.GetAsync();

            Assert.Equal(response[0].Id, result[0].Id);
            Assert.Equal(response[0].ClientId, result[0].ClientId);
            Assert.Equal(response[0].Audience, result[0].Audience);
            Assert.Equal(response[0].Scope, result[0].Scope);
        }

        [Fact]
        public async Task Get_Client_Grants_Paged_OK()
        {
            var response = new ClientGrantsPagedResponse()
            {
                Total = 3,
                Limit = 3,
                Start = 4,
                ClientGrants = new[]
                {
                    new ClientGrantsResponse()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ClientId = Guid.NewGuid().ToString(),
                        Audience = Guid.NewGuid().ToString(),
                        Scope = new[]
                        {
                            Guid.NewGuid().ToString(),
                        }
                    }
                }
            };
            var client = TestsHelper.GetClient(response, HttpStatusCode.OK);
            var result = await client.ClientGrants.GetPagedAsync(25, 0);

            Assert.Equal(response.Limit, result.Limit);
            Assert.Equal(response.Total, result.Total);
            Assert.Equal(response.Start, result.Start);
        }

        [Fact]
        public async Task Create_Client_Grants_Ok()
        {
            var client = TestsHelper.GetClient(null, HttpStatusCode.Created);
            var result = await client.ClientGrants.CreateAsync(new ClientGrantRequest() { Audience = "test", ClientId = "test" });
            Assert.True(result);
        }
    }
}

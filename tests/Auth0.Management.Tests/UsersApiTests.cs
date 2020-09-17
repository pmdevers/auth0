using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Auth0.Management.Tests
{
    public class UsersApiTests
    {
        [Fact]
        public async Task Get_User_By_Id()
        {
            var services = new ServiceCollection();
            
            services.AddAuthManagement(opt =>
            {
                opt.ClientId = "SNzEII6xnjObhe5T25Zmv52KZErNRCyy";
                opt.ClientSecret = "SaTIjvCbrzcyXgaBe2WO-p2BiOz7cEC4f0rRkYf48e4RdoRz9rw8PPYqZVeqNxU6";
                opt.Audience = new Uri("https://domivest.eu.auth0.com/api/v2/");
                opt.Domain = new Uri("https://domivest.eu.auth0.com");
            });

            var provider = services.BuildServiceProvider();

            var client = provider.GetService<ManagementClient>();

            var connections = await client.Connections.GetConnectionsAsync();

            var clients = await client.Clients.GetAsync();

            var clientsb = await client.Clients.GetPagedAsync();

            var user = await client.Users.GetAsync("auth0|5e3d638b76a73e0ed404f46b");

            var log = await client.Users.GetLogsAsync("auth0|5e3ac0ff543f3d10ca5d4278");
            var pageLog = await client.Users.GetLogsPagedAsync("auth0|5e3ac0ff543f3d10ca5d4278");

        }
    }
}

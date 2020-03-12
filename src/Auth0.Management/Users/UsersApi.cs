using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Management.Users.Models;

namespace Auth0.Management.Users
{
    public class UsersApi
    {
        private readonly ManagementClient _client;

        internal UsersApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<UsersResponse> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _client.HttpClient.GetAsync($"api/v2/users/{id}", cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<UsersResponse> CreateAsync(CreateUsersRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PostAsync("api/v2/users",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }
    }
}

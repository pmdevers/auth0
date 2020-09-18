using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Management.Clients.Models;
using Auth0.Management.CusomDomains.Models;

namespace Auth0.Management.CusomDomains
{
    public class CustomDomainApi
    {
        private readonly ManagementClient _client;

        internal CustomDomainApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<GetCustomDomainResponse[]> GetAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var result = await _client.HttpClient.GetAsync("/api/v2/custom-domains", cancellationToken);
            return await _client.HandleResponseAsync<GetCustomDomainResponse[]>(result, cancellationToken);
        }

        public async Task<GetCustomDomainResponse> ConfigureNewAsync(PostCustomDomainBody customDomain,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var content = JsonSerializer.Serialize(customDomain, _client.Options);
            var result = await _client.HttpClient.PostAsync("/api/v2/custom-domains",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<GetCustomDomainResponse>(result, cancellationToken);
        }

        public async Task<GetCustomDomainResponse> GetByIdAsync(string id,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var result = await _client.HttpClient.GetAsync($"/api/v2/custom-domains/{id}", cancellationToken);
            return await _client.HandleResponseAsync<GetCustomDomainResponse>(result, cancellationToken);
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var result = await _client.HttpClient.GetAsync($"/api/v2/custom-domains/{id}", cancellationToken);
            return result.IsSuccessStatusCode;
        }

        public async Task<GetCustomDomainResponse> UpdateAsync(string id, UpdateCustomDomain customDomain,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var content = JsonSerializer.Serialize(customDomain, _client.Options);
            var result = await _client.HttpClient.PatchAsync($"/api/v2/custom-domains/{id}",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<GetCustomDomainResponse>(result, cancellationToken);
        }

        public async Task<GetCustomDomainResponse> VerifyAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var result = await _client.HttpClient.PostAsync($"/api/v2/custom-domains/{id}",
                new StringContent(string.Empty, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<GetCustomDomainResponse>(result, cancellationToken);
        }
    }
}

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Management.Branding.Models;

namespace Auth0.Management.Branding
{
    public class BrandingApi
    {
        private readonly ManagementClient _client;

        internal BrandingApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<BrandingResponse> GetAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _client.HttpClient.GetAsync("/api/branding", cancellationToken);
            return await _client.HandleResponseAsync<BrandingResponse>(response, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateBrandingRequest request, CancellationToken cancellationToken = default)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _client.HttpClient.PatchAsync("/api/branding", content, cancellationToken);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}

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

        /// <summary>
        /// Get branding settings
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Retrieve branding settings.
        /// </returns>
        public async Task<BrandingResponse> GetAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.GetAsync("/api/v2/branding", cancellationToken);
            return await _client.HandleResponseAsync<BrandingResponse>(response, cancellationToken);
        }

        /// <summary>
        /// Update branding settings
        /// </summary>
        /// <param name="request">Branding settings</param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// returns <c>true</c> if succesfull
        /// </returns>
        public async Task<bool> UpdateAsync(BrandingRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _client.HttpClient.PatchAsync("/api/v2/branding", content, cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }
    }
}

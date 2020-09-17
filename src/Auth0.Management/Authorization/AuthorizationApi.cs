using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Management.Authorization.Models;

namespace Auth0.Management.Authorization
{
    public class AuthorizationApi
    {
        private readonly ManagementClient _client;

        public AuthorizationApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<GetTokenResponse> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var request = new GetTokenRequest()
            {
                ClientId = _client.Settings.ClientId,
                ClientSecret = _client.Settings.ClientSecret,
                Audience = _client.Settings.Audience.ToString(),
                GrantType = "client_credentials"
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _client.HttpClient.PostAsync("/oauth/token", content,
                cancellationToken);

            return await _client.HandleResponseAsync<GetTokenResponse>(response, cancellationToken);
        }
    }
}

using System.Text.Json.Serialization;

namespace Auth0.Management.Authorization.Models
{
    public class GetTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }
        [JsonPropertyName("scope")]
        public string scope { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}

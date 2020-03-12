using System.Text.Json.Serialization;

namespace Auth0.Management.ClientGrants.Models
{
    public class ClientGrantsResponse
    {
        public string Id { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string[] Scope { get; set; }
    }
}

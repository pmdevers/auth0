using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.ClientGrants.Models
{
    public class ClientGrantRequest
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        public string Audience { get; set; }
        public string[] Scope { get; set; }
    }
}

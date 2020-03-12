using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.ClientGrants.Models
{
    public class ClientGrantsPagedResponse
    {
        
        public int Total { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        [JsonPropertyName("client_grants")]
        public ClientGrantsResponse[] ClientGrants { get; set; }
    }
}

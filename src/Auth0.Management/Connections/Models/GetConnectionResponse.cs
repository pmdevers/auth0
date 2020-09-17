using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth0.Management.Connections.Models
{
    public class GetClientsPagedResponse
    {
        public int Total { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        [JsonPropertyName("connections")]
        public GetConnectionResponse[] Connections { get; set; }
    }

    public class GetConnectionResponse
    {
        public string name { get; set; }
        public string display_name { get; set; }
        public Dictionary<string, object> options { get; set; }
        public string id { get; set; }
        public string strategy { get; set; }
        public string[] realms { get; set; }
        public bool is_domain_connection { get; set; }
        public Dictionary<string, object> metadata { get; set; }
    }

    public class Options
    {
    }

    public class Metadata
    {
    }
}

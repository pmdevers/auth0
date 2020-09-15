using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Clients.Models
{
    public class GetClientsRequest
    {
        [JsonPropertyName("fields")]
        public string Fields { get; set; }
        [JsonPropertyName("include_fields")]
        public bool IncludeFields { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("include_totals")]
        public bool IncludeTotals { get; set; }
        [JsonPropertyName("is_global")]
        public bool IsGlobal { get; set; }
        [JsonPropertyName("is_first_party")]
        public bool IsFirstParty { get; set; }
        [JsonPropertyName("app_type")]
        public string AppType { get; set; }
    }
}

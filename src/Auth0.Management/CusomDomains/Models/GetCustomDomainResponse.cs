using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.CusomDomains.Models
{
    public class GetCustomDomainResponse
    {
        [JsonPropertyName("custom_domain_id")]
        public string CustomDomainId { get; set; }
        public string Domain { get; set; }
        public bool Primary { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string OriginDomainName { get; set; }
        public Verification Verification { get; set; }
        [JsonPropertyName("custom_client_ip_header")]
        public string CustomClientIpHeader { get; set; }
        [JsonPropertyName("tls_policy")]
        public string TLSPolicy { get; set; }
    }

    public class Verification
    {
        public string[] Methods { get; set; }
    }

}

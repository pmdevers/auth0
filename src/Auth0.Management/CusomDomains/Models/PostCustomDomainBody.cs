using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.CusomDomains.Models
{
    public class PostCustomDomainBody
    {
        public string Domain { get; set; }
        public string Type { get; set; }

        [JsonPropertyName("verification_method")]
        public string VerificationMethod { get; set; } = "txt";

        [JsonPropertyName("tls_policy")] 
        public string TLSPolicy { get; set; } = "recommended";

        [JsonPropertyName("custom_client_ip_header")]
        public string CustomClientIpHeader { get; set; }
    }

}

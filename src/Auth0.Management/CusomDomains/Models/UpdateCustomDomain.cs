using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.CusomDomains.Models
{
    public class UpdateCustomDomain
    {
        [JsonPropertyName("tls_policy")]
        public string TLSPolicy { get; set; } = "recommended";

        [JsonPropertyName("custom_client_ip_header")]
        public string CustomClientIpHeader { get; set; } = "true-client-ip";
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Branding.Models
{
    public class BrandingRequest
    {
        [JsonPropertyName("favicon_url")]
        public Uri FaviconUrl { get; set; }
        [JsonPropertyName("logo_url")]
        public Uri LogoUrl { get; set; }
    }
}

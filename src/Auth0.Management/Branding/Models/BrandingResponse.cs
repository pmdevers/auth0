using System;
using System.Text.Json.Serialization;

namespace Auth0.Management.Branding.Models
{
    public class BrandingResponse
    {
        [JsonPropertyName("favicon_url")]
        public Uri FaviconUrl { get; set; }
        [JsonPropertyName("logo_url")]
        public Uri LogoUrl { get; set; }
    }
}

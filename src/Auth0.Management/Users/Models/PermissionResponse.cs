using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{

    public class PermissionRepsonse
    {
        [JsonPropertyName("resource_server_identifier")]
        public string ResourceServerIdentifier { get; set; }
        [JsonPropertyName("permission_name")]

        public string PermissionName { get; set; }
        [JsonPropertyName("resource_server_name")]
        public string ResourceServerName { get; set; }
        public string Description { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{

    public class DeleteIdentityResponse
    {
        public string Connection { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public string Provider { get; set; }
        public bool IsSocial { get; set; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }

}

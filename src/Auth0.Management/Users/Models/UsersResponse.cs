using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{
    public class UsersResponse
    {

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        public string Username { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("phone_verified")]
        public bool PhoneVerified { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        public Identity[] Identities { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string[] Multifactor { get; set; }

        [JsonPropertyName("last_ip")]
        public string LastIp { get; set; }

        [JsonPropertyName("last_login")]
        public string LastLogin { get; set; }

        [JsonPropertyName("logins_count")]
        public int LoginsCount { get; set; }

        public bool Blocked { get; set; }

        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }

        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }

        [JsonPropertyName("user_metadata")]
        public object UserMetaData { get; set; }

        [JsonPropertyName("app_metadata")]
        public object AppMetaData { get; set; }

    }

    public class Identity
    {
        public string Connection { get; set; }
        
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public string Provider { get; set; }
        public bool IsSocial { get; set; }
    }
}

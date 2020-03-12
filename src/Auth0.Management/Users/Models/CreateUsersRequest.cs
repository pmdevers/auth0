using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{
    public class CreateUsersRequest
    {
        public string Email { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        public bool Blocked { get; set; }
        [JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }
        [JsonPropertyName("phone_verified")]
        public bool PhoneVerified { get; set; }
        [JsonPropertyName("given_name")]
        public string GivenName { get; set; }
        [JsonPropertyName("family_name")]
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Picture { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public string Connection { get; set; }
        public string Password { get; set; }
        [JsonPropertyName("verify_email")]
        public bool VerifyEmail { get; set; }
        public string Username { get; set; }
    }

}

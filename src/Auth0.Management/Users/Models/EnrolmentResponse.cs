using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{

    public class EnrollmentsResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("auth_method")]
        public string AuthMethod { get; set; }
        [JsonPropertyName("enrolled_at")]
        public string EnrolledAt { get; set; }
        [JsonPropertyName("last_auth")]
        public string LastAuth { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.DeviceCredentials.Model
{
    public class GetDeviceCredentialsResponse
    {
        public string Id { get; set; }
        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }
        [JsonPropertyName("DeviceId")]
        public string DeviceId { get; set; }
        public string Yype { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
    }

}

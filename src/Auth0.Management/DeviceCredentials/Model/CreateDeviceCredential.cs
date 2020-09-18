using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.DeviceCredentials.Model
{
    public class CreateDeviceCredential
    {
        [JsonPropertyName("device_name")]
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
    }
}

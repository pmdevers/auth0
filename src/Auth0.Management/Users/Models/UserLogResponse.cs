using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Auth0.Management.Users.Models
{

    public class UserLogResponse
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Connection { get; set; }
        [JsonPropertyName("connection_id")]
        public string ConnectionId { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        [JsonPropertyName("client_name")]
        public string ClientName { get; set; }
        public string Ip { get; set; }
        public string Hostname { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Audience { get; set; }
        public string Scope { get; set; }
        public string Strategy { get; set; }
        [JsonPropertyName("strategy_type")]
        public string StrategyType { get; set; }
        [JsonPropertyName("log_id")]
        public string LogId { get; set; }
        public bool IsMobile { get; set; }
        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }

        [JsonPropertyName("auth0_client")]
        public Auth0Client Auth0Client { get; set; }
        [JsonPropertyName("location_info")]
        public LocationInfo LocationInfo { get; set; }
    }


    public class Auth0Client
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class LocationInfo
    {
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        [JsonPropertyName("country_code3")]
        public string CountryCode3 { get; set; }
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [JsonPropertyName("time_zone")]
        public string TimeZone { get; set; }
        [JsonPropertyName("continent_code")]
        public string ContinentCode { get; set; }
    }

}

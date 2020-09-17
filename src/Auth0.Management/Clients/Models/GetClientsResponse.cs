using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Auth0.Management.ClientGrants.Models;

namespace Auth0.Management.Clients.Models
{
    public class GetClientsPagedResponse {
        public int Total { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        [JsonPropertyName("clients")]
        public GetClientsResponse[] Clients { get; set; }
    }


    public class GetClientsResponse
    {
        public string tenant { get; set; }
        public string description { get; set; }
        public bool global { get; set; }
        public bool is_token_endpoint_ip_header_trusted { get; set; }
        public string name { get; set; }
        public string[] callbacks { get; set; }
        public bool is_first_party { get; set; }
        public bool oidc_conformant { get; set; }
        public bool sso_disabled { get; set; }
        public bool cross_origin_auth { get; set; }
        public object[] allowed_clients { get; set; }
        public string[] allowed_logout_urls { get; set; }
        public string logo_uri { get; set; }
        public Native_Social_Login native_social_login { get; set; }
        public Refresh_Token refresh_token { get; set; }
        public Signing_Keys[] signing_keys { get; set; }
        public string client_id { get; set; }
        public bool callback_url_template { get; set; }
        public string client_secret { get; set; }
        public Jwt_Configuration jwt_configuration { get; set; }
        public object[] client_aliases { get; set; }
        public string token_endpoint_auth_method { get; set; }
        public string app_type { get; set; }
        public string[] grant_types { get; set; }
        public string[] web_origins { get; set; }
        public bool custom_login_page_on { get; set; }
    }

    public class Native_Social_Login
    {
        public Apple apple { get; set; }
        public Facebook facebook { get; set; }
    }

    public class Apple
    {
        public bool enabled { get; set; }
    }

    public class Facebook
    {
        public bool enabled { get; set; }
    }

    public class Refresh_Token
    {
        public string rotation_type { get; set; }
        public string expiration_type { get; set; }
    }

    public class Jwt_Configuration
    {
        public string alg { get; set; }
        public int lifetime_in_seconds { get; set; }
        public bool secret_encoded { get; set; }
    }

    public class Signing_Keys
    {
        public string cert { get; set; }
        public string pkcs7 { get; set; }
        public string subject { get; set; }
    }

}

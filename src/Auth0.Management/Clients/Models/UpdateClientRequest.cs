using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.Management.Clients.Models
{
    public class UpdateClientRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public string client_secret { get; set; }
        public string logo_uri { get; set; }
        public string[] callbacks { get; set; }
        public string[] allowed_origins { get; set; }
        public string[] web_origins { get; set; }
        public string[] grant_types { get; set; }
        public string[] client_aliases { get; set; }
        public string[] allowed_clients { get; set; }
        public string[] allowed_logout_urls { get; set; }
        public Jwt_Configuration jwt_configuration { get; set; }
        public Encryption_Key encryption_key { get; set; }
        public bool sso { get; set; }
        public bool cross_origin_auth { get; set; }
        public string cross_origin_loc { get; set; }
        public bool sso_disabled { get; set; }
        public bool custom_login_page_on { get; set; }
        public string token_endpoint_auth_method { get; set; }
        public string app_type { get; set; }
        public bool is_first_party { get; set; }
        public bool oidc_conformant { get; set; }
        public string custom_login_page { get; set; }
        public string custom_login_page_preview { get; set; }
        public string form_template { get; set; }
        public Addons addons { get; set; }
        public Client_Metadata client_metadata { get; set; }
        public Mobile mobile { get; set; }
        public string initiate_login_uri { get; set; }
        public Native_Social_Login native_social_login { get; set; }
        public Refresh_Token refresh_token { get; set; }
    }
    
    public class Scopes
    {
    }

    public class Encryption_Key
    {
        public string pub { get; set; }
        public string cert { get; set; }
        public string subject { get; set; }
    }

    public class Addons
    {
        public Aws aws { get; set; }
        public Azure_Blob azure_blob { get; set; }
        public Azure_Sb azure_sb { get; set; }
        public Rms rms { get; set; }
        public Mscrm mscrm { get; set; }
        public Slack slack { get; set; }
        public Sentry sentry { get; set; }
        public Box box { get; set; }
        public Cloudbees cloudbees { get; set; }
        public Concur concur { get; set; }
        public Dropbox dropbox { get; set; }
        public Echosign echosign { get; set; }
        public Egnyte egnyte { get; set; }
        public Firebase firebase { get; set; }
        public Newrelic newrelic { get; set; }
        public Office365 office365 { get; set; }
        public Salesforce salesforce { get; set; }
        public Salesforce_Api salesforce_api { get; set; }
        public Salesforce_Sandbox_Api salesforce_sandbox_api { get; set; }
        public Samlp samlp { get; set; }
        public Layer layer { get; set; }
        public Sap_Api sap_api { get; set; }
        public Sharepoint sharepoint { get; set; }
        public Springcm springcm { get; set; }
        public Wams wams { get; set; }
        public Wsfed wsfed { get; set; }
        public Zendesk zendesk { get; set; }
        public Zoom zoom { get; set; }
        public string sso_integration { get; set; }
    }

    public class Aws
    {
    }

    public class Azure_Blob
    {
    }

    public class Azure_Sb
    {
    }

    public class Rms
    {
    }

    public class Mscrm
    {
    }

    public class Slack
    {
    }

    public class Sentry
    {
    }

    public class Box
    {
    }

    public class Cloudbees
    {
    }

    public class Concur
    {
    }

    public class Dropbox
    {
    }

    public class Echosign
    {
    }

    public class Egnyte
    {
    }

    public class Firebase
    {
    }

    public class Newrelic
    {
    }

    public class Office365
    {
    }

    public class Salesforce
    {
    }

    public class Salesforce_Api
    {
    }

    public class Salesforce_Sandbox_Api
    {
    }

    public class Samlp
    {
    }

    public class Layer
    {
    }

    public class Sap_Api
    {
    }

    public class Sharepoint
    {
    }

    public class Springcm
    {
    }

    public class Wams
    {
    }

    public class Wsfed
    {
    }

    public class Zendesk
    {
    }

    public class Zoom
    {
    }

    public class Client_Metadata
    {
    }

    public class Mobile
    {
        public Android android { get; set; }
        public Ios ios { get; set; }
    }

    public class Android
    {
        public string app_package_name { get; set; }
        public string[] sha256_cert_fingerprints { get; set; }
    }

    public class Ios
    {
        public string team_id { get; set; }
        public string app_bundle_identifier { get; set; }
    }
}

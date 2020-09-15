using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.Authentication.Infrastructure
{
    public class AuthenticationClientSettings
    {
        public Uri Domain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri Audience { get; set; }
    }
}

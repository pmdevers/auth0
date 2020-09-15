using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0.Management.Infrastructure
{
    public class ManagementClientSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri Audience { get; set; }
        public Uri Domain { get; set; }
    }
}
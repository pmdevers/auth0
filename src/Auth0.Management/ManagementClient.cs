﻿using Auth0.Management.Branding;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Management.ClientGrants;
using Auth0.Management.Users;

namespace Auth0.Management
{
    public class ManagementClient
    {
        public JsonSerializerOptions Options => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public ManagementClient(HttpClient client, ILogger<ManagementClient> logger)
        {
            HttpClient = client;
            Logger = logger;
        }

        public HttpClient HttpClient { get; }
        public ILogger Logger { get; }

        public BrandingApi Branding => new BrandingApi(this);
        public ClientGrantsApi ClientGrants => new ClientGrantsApi(this);
        public UsersApi Users => new UsersApi(this);

        internal async Task<T> HandleResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await HandleErrorAsync(response, cancellationToken);

            var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<T>(stream, Options, cancellationToken);
            return result;
        }

        internal async Task HandleErrorAsync(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (response.IsSuccessStatusCode)
                return;

            var stream = await response.Content.ReadAsStreamAsync();
            using var sr = new StreamReader(stream);
            var message = await sr.ReadToEndAsync();
            var exception = new ManagementClientException(response.StatusCode, message);
            Logger.LogError((int)response.StatusCode, exception, message);
            throw exception;
        }

        public string GetIdentityProviderString(IdentityProvider provider)
        {
            switch (provider)
            {
                case IdentityProvider.EvernoteSandbox:
                    return "evernote-sandbox";
                case IdentityProvider.GoogleApps:
                    return "google-apps";
                case IdentityProvider.GoogleOauth2:
                    return "google-oauth2";
                case IdentityProvider.PaypalSandbox:
                    return "paypal-sandbox";
                case IdentityProvider.SalesforceCommunity:
                    return "salesforce-community";
                case IdentityProvider.SalesforceSandbox:
                    return "salesforce-sandbox";
                case IdentityProvider.ThecitySandbox:
                    return "thecity-sandbox";
                case IdentityProvider.Auth0Adldap:
                    return "auth0-adldap";
                case IdentityProvider.Auth0Oidc:
                    return "auth0-oidc";
                default:
                {
                    return provider.ToString().ToLower();
                }
            }
        }
    }
}

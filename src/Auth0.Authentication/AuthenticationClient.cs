using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Authentication.Authorization;
using Auth0.Authentication.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Auth0.Authentication
{
    public class AuthenticationClient
    {
        

        public JsonSerializerOptions Options => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public AuthenticationClient(HttpClient client, ILogger<AuthenticationClient> logger, AuthenticationClientSettings settings)
        {
            HttpClient = client;
            Logger = logger;
            Settings = settings;
        }

        
        public HttpClient HttpClient { get; }
        public ILogger Logger { get; }
        public AuthenticationClientSettings Settings { get; }

        

        

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
            var exception = new AuthenticationClientException(response.StatusCode, message);
            Logger.LogError((int)response.StatusCode, exception, message);
            throw exception;
        }
    }
}

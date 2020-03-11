using Auth0.Management.Branding;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.Management
{
    public class ManagementClient
    {
        public ManagementClient(HttpClient client, ILogger<ManagementClient> logger)
        {
            HttpClient = client;
            Logger = logger;
        }

        public HttpClient HttpClient { get; }
        public ILogger Logger { get; }

        public BrandingApi Branding => new BrandingApi(this);


        internal async Task<T> HandleResponseAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<T>(stream, null, cancellationToken);
            }
            else
            {
                using (var sr = new StreamReader(stream))
                {
                    var message = await sr.ReadToEndAsync();
                    var exception = new ManagementClientException(response.StatusCode, message);
                    Logger.LogError((int)response.StatusCode, exception, message);
                    throw exception;
                }
            }
        }
	}
}

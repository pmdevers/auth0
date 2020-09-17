using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Management.Clients.Models;

namespace Auth0.Management.Clients
{
    public class ClientsApi 
    {
        private readonly ManagementClient _client;

        public ClientsApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<GetClientsResponse> GetByIdAsync(string clientId, string fields = "", bool? includeFields = null, CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrEmpty(clientId)) throw new ArgumentNullException(nameof(clientId));

                cancellationToken.ThrowIfCancellationRequested();
            var query = new NameValueCollection();

            if (!string.IsNullOrEmpty(fields))
            {
                query.Add("fields", fields);

                if (includeFields != null)
                {
                    query.Add("include_fields", includeFields.ToString().ToLower());
                }
            }

            var querystring = query.ToQueryString();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var results = await _client.HttpClient.GetAsync($"api/v2/clients/{clientId}" + querystring, cancellationToken);
            return await _client.HandleResponseAsync<GetClientsResponse>(results, cancellationToken);
        }

        public async Task<bool> DeleteAsync(string clientId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentNullException(nameof(clientId));
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var results = await _client.HttpClient.DeleteAsync($"api/v2/clients/{clientId}", cancellationToken);
            return results.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string clientId, UpdateClientRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentNullException(nameof(clientId));
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var content = JsonSerializer.Serialize(request, _client.Options);
            var results = await _client.HttpClient.PatchAsync($"api/v2/clients/{clientId}", new StringContent(content, Encoding.UTF8, "application/json"),  cancellationToken);
            return results.IsSuccessStatusCode;
        }

        public async Task<GetClientsResponse> RotateSecretAsync(string clientId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentNullException(nameof(clientId));
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var results = await _client.HttpClient.PostAsync($"api/v2/clients/{clientId}", new StringContent(""), cancellationToken);
            return await _client.HandleResponseAsync<GetClientsResponse>(results, cancellationToken);
        }

        public async Task<GetClientsResponse[]> GetAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await GetImplAsync(cancellationToken: cancellationToken);
            return await _client.HandleResponseAsync<GetClientsResponse[]>(response, cancellationToken);
        }

        public async Task<GetClientsPagedResponse> GetPagedAsync(int itemsPerPage = 25, int page = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await GetImplAsync(page: page, itemsPerPage: itemsPerPage, includeTotals: true, cancellationToken: cancellationToken);
            return await _client.HandleResponseAsync<GetClientsPagedResponse>(response, cancellationToken);
        }

        private async Task<HttpResponseMessage> GetImplAsync(string fields = "", bool? includeFields = null, int itemsPerPage = 25, int page = 0, bool includeTotals = false, bool? isGlobal = null, bool? isFirstParty = null, string appTypes = "", CancellationToken cancellationToken = default)
        {
            var query = new NameValueCollection();

            if (!string.IsNullOrEmpty(fields))
            {
                query.Add("fields", fields);

                if (includeFields != null)
                {
                    query.Add("include_fields", includeFields.ToString().ToLower());
                }
                
            }

            if (itemsPerPage != 0)
            {
                query.Add("page", page.ToString());
                query.Add("per_page", itemsPerPage.ToString());
            }

            query.Add("include_totals", includeTotals.ToString().ToLower());

            if (isGlobal != null)
            {
                query.Add("is_global", isGlobal.ToString().ToLower());
            }

            if (isFirstParty != null)
            {
                query.Add("is_first_party", isFirstParty.ToString().ToLower());
            }

            if (!string.IsNullOrEmpty(appTypes))
            {
                query.Add("app_types", appTypes);
            }

            var querystring = query.ToQueryString();
            await _client.SetAuthHeaderAsync(cancellationToken);
            return await _client.HttpClient.GetAsync("api/v2/clients" + querystring, cancellationToken);
        }
    }
}

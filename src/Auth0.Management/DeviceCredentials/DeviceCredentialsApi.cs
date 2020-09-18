using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Management.DeviceCredentials.Model;

namespace Auth0.Management.DeviceCredentials
{
    public class DeviceCredentialsApi
    {
        private readonly ManagementClient _client;

        internal DeviceCredentialsApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<GetDeviceCredentialsResponse[]> GetAsync(string userId, string clientId = "", string type = "", string fields = "", CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await GetImplAsync(userId: userId, clientId: clientId, type: type,
                cancellationToken: cancellationToken);
            return await _client.HandleResponseAsync<GetDeviceCredentialsResponse[]>(result, cancellationToken);
        }

        public async Task<PagedDeviceCredentialsResponse> GetPagedAsync(string userId, int page = 0, int itemsPerPage = 25, string clientId = "", string type = "", string fields = "", CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await GetImplAsync(userId: userId, clientId: clientId, type: type,
                page:page, itemsPerPage:itemsPerPage, includeTotals: true, fields: fields, 
                cancellationToken: cancellationToken);
            return await _client.HandleResponseAsync<PagedDeviceCredentialsResponse>(result, cancellationToken);
        }

        public async Task<string> CreateAsync(CreateDeviceCredential deviceCredential, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var content = new StringContent(JsonSerializer.Serialize(deviceCredential), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/v2/device-credentials")
            {
                Content = content
            };
            var response = await _client.HttpClient.SendAsync(request, cancellationToken);
            var model = await _client.HandleResponseAsync<PostDeviceCredentialsResponse>(response, cancellationToken);
            return model.Id;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeaderAsync(cancellationToken);
            var response = await _client.HttpClient.DeleteAsync($"api/v2/device-credentials/{id}", cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }


        private async Task<HttpResponseMessage> GetImplAsync(int itemsPerPage = 25, int page = 0, bool? includeTotals = null, 
            string fields = "", string userId = "", string clientId = "",
            string type = "",
            CancellationToken cancellationToken = default)
        {
            var query = new NameValueCollection();

            if (itemsPerPage != 0)
            {
                query.Add("per_page", itemsPerPage.ToString());
                query.Add("page", page.ToString());
            }

            if (includeTotals != null)
            {
                query.Add("include_totals", includeTotals.ToString().ToLower());
            }

            if (!string.IsNullOrEmpty(fields))
            {
                query.Add("fields", fields);
            }

            if (!string.IsNullOrEmpty(userId))
            {
                query.Add("user_id", userId);
            }

            if (!string.IsNullOrEmpty(clientId))
            {
                query.Add("client_id", clientId);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query.Add("type", type);
            }

            var querystring = query.ToQueryString();
            await _client.SetAuthHeaderAsync(cancellationToken);
            return await _client.HttpClient.GetAsync($"api/v2/device-credentials" + querystring, cancellationToken);
        }

    }
}

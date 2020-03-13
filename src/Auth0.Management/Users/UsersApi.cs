using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Management.Users.Models;

namespace Auth0.Management.Users
{
    public class UsersApi
    {
        private readonly ManagementClient _client;

        internal UsersApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<UsersResponse> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _client.HttpClient.GetAsync($"api/v2/users/{id}", cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<UsersResponse> CreateAsync(UsersRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PostAsync("api/v2/users",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _client.HttpClient.DeleteAsync($"api/v2/users/{id}", cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<UsersResponse> UpdateAsync(string id, UsersRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PatchAsync($"api/v2/users/{id}",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<UserLogResponse[]> GetLogsAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await GetLogsImplAsync(id, 0, 0, false, string.Empty, cancellationToken);
            return await _client.HandleResponseAsync<UserLogResponse[]>(response, cancellationToken);
        }

        public async Task<PagedUserLogResponse> GetLogsPagedAsync(string id, int itemsPerPage = 25, int page = 0, string sort = "",
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await GetLogsImplAsync(id, itemsPerPage, page, true, sort, cancellationToken);
            return await _client.HandleResponseAsync<PagedUserLogResponse>(response, cancellationToken);
        }

        private async Task<HttpResponseMessage> GetLogsImplAsync(string id, int itemsPerPage = 25, int page = 0, bool includeTotals = false, string sort = "",
            CancellationToken cancellationToken = default)
        {
            var query = new NameValueCollection();

            if (itemsPerPage != 0)
            {
                query.Add("per_page", itemsPerPage.ToString());
                query.Add("page", page.ToString());
            }

            query.Add("include_totals", includeTotals.ToString().ToLower());

            if (!string.IsNullOrEmpty(sort))
            {
                query.Add("sort", sort);
            }

            var querystring = query.ToQueryString();
            return await _client.HttpClient.GetAsync($"api/v2/users/{id}/logs" + querystring, cancellationToken);
        }
    }
}

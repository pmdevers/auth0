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
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.GetAsync($"api/v2/users/{id}", cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<UsersResponse> CreateAsync(UsersRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PostAsync("api/v2/users",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.DeleteAsync($"api/v2/users/{id}", cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<UsersResponse> UpdateAsync(string id, UsersRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PatchAsync($"api/v2/users/{id}",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return await _client.HandleResponseAsync<UsersResponse>(response, cancellationToken);
        }

        public async Task<UserLogResponse[]> GetLogsAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await GetLogsImplAsync(id, 0, 0, false, string.Empty, cancellationToken);
            return await _client.HandleResponseAsync<UserLogResponse[]>(response, cancellationToken);
        }

        public async Task<PagedUserLogResponse> GetLogsPagedAsync(string id, int itemsPerPage = 25, int page = 0, string sort = "",
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await GetLogsImplAsync(id, itemsPerPage, page, true, sort, cancellationToken);
            return await _client.HandleResponseAsync<PagedUserLogResponse>(response, cancellationToken);
        }

        public async Task<EnrollmentsResponse[]> GetEnrollmentsAsync(string id,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.GetAsync($"api/v2/users/{id}/enrollments", cancellationToken);
            return await _client.HandleResponseAsync<EnrollmentsResponse[]>(response, cancellationToken);
        }

        public async Task<UserRoleResponse[]> GetRolesAsync(string id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.GetAsync($"api/users/{id}/roles", cancellationToken);
            return await _client.HandleResponseAsync<UserRoleResponse[]>(response, cancellationToken);
        }

        public async Task<bool> AssignRolesASync(string id, RolesRequest roles,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = new StringContent(JsonSerializer.Serialize(roles), Encoding.UTF8, "application/json");
            var response = await _client.HttpClient.PostAsync($"api/v2/users/{id}/roles", content, cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteRolesAsync(string id, RolesRequest roles, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = new StringContent(JsonSerializer.Serialize(roles), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/v2/users/{id}/roles")
            {
                Content = content
            };
            var response = await _client.HttpClient.SendAsync(request, cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<PermissionRepsonse[]> GetPermissionsAsync(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var request = await _client.HttpClient.GetAsync($"api/v2/users/{id}permissions", cancellationToken);
            return await _client.HandleResponseAsync<PermissionRepsonse[]>(request, cancellationToken);
        }

        public async Task<bool> AssignPermissionsAsync(string id, PermissionRequest permissions,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = new StringContent(JsonSerializer.Serialize(permissions), Encoding.UTF8, "application/json");
            var response =
                await _client.HttpClient.PostAsync($"api/v2/users/{id}/permissions", content, cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePermissionsAsync(string id, PermissionRequest permissions, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _client.SetAuthHeader();
            var content = new StringContent(JsonSerializer.Serialize(permissions), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/v2/users/{id}/permissions")
            {
                Content = content
            };
            var response = await _client.HttpClient.SendAsync(request, cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMultifactorProvider(string id, MultifactorProvider provider,
            CancellationToken cancellationToken = default)
        {
            await _client.SetAuthHeader();
            var response = await _client.HttpClient.DeleteAsync($"api/v2/users/{id}/provider/{provider}", cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<DeleteIdentityResponse[]> DeleteIdentityAsync(string id, IdentityProvider provider, string userId, CancellationToken cancellationToken = default)
        {
            await _client.SetAuthHeader();
            var p = _client.GetIdentityProviderString(provider);
            var response = await _client.HttpClient.DeleteAsync($"api/v2/users/{id}/provider/{p}/{userId}", cancellationToken);
            await _client.HandleErrorAsync(response, cancellationToken);
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<DeleteIdentityResponse[]>(stream, _client.Options,
                cancellationToken);
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
            await _client.SetAuthHeader();
            return await _client.HttpClient.GetAsync($"api/v2/users/{id}/logs" + querystring, cancellationToken);
        }


       
    }
}

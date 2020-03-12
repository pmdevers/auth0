﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Management.ClientGrants.Models;

namespace Auth0.Management.ClientGrants
{
    public class ClientGrantsApi
    {
        private readonly ManagementClient _client;

        internal ClientGrantsApi(ManagementClient client)
        {
            _client = client;
        }

        public async Task<ClientGrantsResponse[]> GetAsync(string audience = "", string clientId = "")
        {
            var response = await GetImplAsync(0, 0, false, audience, clientId);
            return await _client.HandleResponseAsync<ClientGrantsResponse[]>(response);
        }

        public async Task<ClientGrantsPagedResponse> GetPagedAsync(int itemsPerPage = 25, int page = 0, string audience = "", string clientId = "")
        {
            var response = await GetImplAsync(itemsPerPage, page, true, audience, clientId);
            return await _client.HandleResponseAsync<ClientGrantsPagedResponse>(response);
        }

        public async Task<bool> CreateAsync(ClientGrantRequest request, CancellationToken cancellationToken = default)
        {
            var content = JsonSerializer.Serialize(request, _client.Options);
            var response = await _client.HttpClient.PostAsync("api/v2/client-grants",
                new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var respose = await _client.HttpClient.DeleteAsync($"api/v2/client-grants/{id}", cancellationToken);
            return respose.IsSuccessStatusCode;
        }

        private async Task<HttpResponseMessage> GetImplAsync(int itemsPerPage = 25, int page = 0, bool includeTotals = false, string audience = "", string clientId = "")
        {
            var query = new NameValueCollection();

            if (itemsPerPage != 0)
            {
                query.Add("per_page", itemsPerPage.ToString());
                query.Add("page", page.ToString());
            }
            
            query.Add("include_totals", includeTotals.ToString().ToLower());

            if (!string.IsNullOrEmpty(audience))
            {
                query.Add("audience", audience);
            }

            if (!string.IsNullOrEmpty(clientId))
            {
                query.Add("client_id", clientId);
            }

            var querystring = query.ToQueryString();
            return await _client.HttpClient.GetAsync("api/v2/client-grants" + querystring);
        }

        
    }
}

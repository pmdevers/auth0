using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Auth0.Management.Clients.Models;
using Auth0.Management.Connections.Models;

namespace Auth0.Management.Connections
{
    public class ConnectionsApi
    {
        private readonly ManagementClient _client;

        public ConnectionsApi(ManagementClient client)
        {
            _client = client;
        }


        public async Task<GetConnectionResponse[]> GetConnectionsAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await GetImplAsync(cancellationToken: cancellationToken);
            return await _client.HandleResponseAsync<GetConnectionResponse[]>(response, cancellationToken);
        }


        private async Task<HttpResponseMessage> GetImplAsync(string strategy = "", string name = "", string fields = "", bool? includeFields = null, int itemsPerPage = 25, int page = 0, bool? includeTotals = null, bool? isGlobal = null, bool? isFirstParty = null, string appTypes = "", CancellationToken cancellationToken = default)
        {
            var query = new NameValueCollection();

            if (!string.IsNullOrEmpty(strategy))
            {
                query.Add("strategy", strategy);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query.Add("name", name);
            }
            
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

            if (includeTotals != null)
            {
                query.Add("include_totals", includeTotals.ToString().ToLower());
            }

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
            return await _client.HttpClient.GetAsync("api/v2/connections" + querystring, cancellationToken);
        }
    }
}

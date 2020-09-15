using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.Management.Tests
{
    public class FakeHttpMessageHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _fakeResponse;

        public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            _fakeResponse = responseMessage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.AbsolutePath.Equals("/oauth/token"))
            {
                return new HttpResponseMessage()
                  
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                        "{ " +
                        "   \"access_token\":\"eyJz93a...k4laUWw\", " +
                        "   \"refresh_token\":\"GEbRxBN...edjnXbL\"," +
                        "   \"id_token\":\"eyJ0XAi...4faeEoQ\"," +
                        "   \"token_type\":\"Bearer\"," +
                        "   \"expires_in\":86400" +
                        "}", Encoding.UTF8,
                        "application/json")
                };
            }

            return await Task.FromResult(_fakeResponse);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Auth0.Management
{

    [Serializable]
    public class ManagementClientException : Exception
    {
        public ManagementClientException() { }
        public ManagementClientException(HttpStatusCode statusCode, string message) : base(message) {
            StatusCode = statusCode;
        }
        public ManagementClientException(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner) {
            StatusCode = statusCode;
        }
        protected ManagementClientException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public HttpStatusCode StatusCode { get; }
    }
}

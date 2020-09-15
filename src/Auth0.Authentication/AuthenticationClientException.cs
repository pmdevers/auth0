using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Auth0.Authentication
{
    [Serializable]
    public class AuthenticationClientException : Exception
    {

        public AuthenticationClientException() { }
        public AuthenticationClientException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public AuthenticationClientException(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }
        protected AuthenticationClientException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public HttpStatusCode StatusCode { get; }
    }
}

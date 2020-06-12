using System;
using System.Collections.Generic;
using System.Net;

namespace BlazorConduit.Client.Models.Common
{
#pragma warning disable RCS1194 // Implement exception constructors.
    public class ConduitApiException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        public ConduitApiException(string message, HttpStatusCode statusCode, IEnumerable<string>? apiErrors = null)
            : base(message)
        {
            StatusCode = statusCode;
            ApiErrors = apiErrors;
        }

        public HttpStatusCode StatusCode { get; }

        public IEnumerable<string>? ApiErrors { get; }
    }
}

// <copyright file="HttpResponseException.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interceptor
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
        }

        public HttpResponseException(string message)
            : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

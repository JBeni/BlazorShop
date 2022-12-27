// <copyright file="HttpResponseException.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interceptor
{
    /// <summary>
    /// .
    /// </summary>
    [Serializable]
    internal class HttpResponseException : Exception
    {
        /// <summary>
        /// .
        /// </summary>
        public HttpResponseException()
        {
        }

        /// <summary>
        /// .
        /// </summary>
        public HttpResponseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// .
        /// </summary>
        public HttpResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// .
        /// </summary>
        protected HttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

// <copyright file="HttpInterceptorService.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interceptor
{
    /// <summary>
    /// A middleware between the server and client to intercept the server response.
    /// </summary>
    public class HttpInterceptorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpInterceptorService"/> class.
        /// </summary>
        /// <param name="interceptor">The instance of the <see cref="HttpClientInterceptor"/> to use.</param>
        /// <param name="navManager">The instance of the <see cref="NavigationManager"/> to use.</param>
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            this.Interceptor = interceptor;
            this.NavManager = navManager;
        }

        /// <summary>
        /// Gets the instance of the <see cref="HttpClientInterceptor"/> to use.
        /// </summary>
        private HttpClientInterceptor Interceptor { get; }

        /// <summary>
        /// Gets the instance of the <see cref="NavigationManager"/> to use.
        /// </summary>
        private NavigationManager NavManager { get; }

        /// <summary>
        /// Register the event.
        /// </summary>
        #pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        public void RegisterEvent() => this.Interceptor.AfterSend += this.InterceptResponse;
        #pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

        /// <summary>
        /// Remove the event.
        /// </summary>
        #pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        public void DisposeEvent() => this.Interceptor.AfterSend -= this.InterceptResponse;
        #pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

        /// <summary>
        /// Intercept the response and check for the error code received from the server.
        /// </summary>
        private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (!e.Response.IsSuccessStatusCode)
            {
                var statusCode = e.Response.StatusCode;

                string message;
                switch (statusCode)
                {
                    case HttpStatusCode.NotFound:
                        this.NavManager.NavigateTo("/not-found");
                        message = "The requested resource was not found.";
                        break;
                    case HttpStatusCode.Unauthorized:
                        this.NavManager.NavigateTo("/unauthorized");
                        message = "User is not authorized";
                        break;
                    case HttpStatusCode.Forbidden:
                        this.NavManager.NavigateTo("/unauthorized");
                        message = "User is not authorized";
                        break;
                    default:
                        this.NavManager.NavigateTo("/server-error");
                        message = "Something went wrong, please contact Administrator";
                        break;
                }

                throw new HttpResponseException(message);
            }
        }
    }
}

// <copyright file="HttpInterceptorService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interceptor
{
    /// <summary>
    /// .
    /// </summary>
    public class HttpInterceptorService
    {
        /// <summary>
        /// .
        /// </summary>
        private readonly HttpClientInterceptor _interceptor;

        /// <summary>
        /// .
        /// </summary>
        private readonly NavigationManager _navManager;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="interceptor"></param>
        /// <param name="navManager"></param>
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navManager = navManager;
        }

        /// <summary>
        /// .
        /// </summary>
        public void RegisterEvent() => _interceptor.AfterSend += this.InterceptResponse;

        /// <summary>
        /// .
        /// </summary>
        private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (!e.Response.IsSuccessStatusCode)
            {
                var statusCode = e.Response.StatusCode;

                string message = string.Empty;
                switch (statusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/not-found");
                        message = "The requested resource was not found.";
                        break;
                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("/unauthorized");
                        message = "User is not authorized";
                        break;
                    default:
                        _navManager.NavigateTo("/server-error");
                        message = "Something went wrong, please contact Administrator";
                        break;
                }

                throw new HttpResponseException(message);
            }
        }

        /// <summary>
        /// .
        /// </summary>
        public void DisposeEvent() => _interceptor.AfterSend -= this.InterceptResponse;
    }
}

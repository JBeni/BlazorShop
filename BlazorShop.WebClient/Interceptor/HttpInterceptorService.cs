// <copyright file="HttpInterceptorService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interceptor
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;

        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navManager = navManager;
        }

        public void RegisterEvent() => _interceptor.AfterSend += this.InterceptResponse;

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

        public void DisposeEvent() => _interceptor.AfterSend -= this.InterceptResponse;
    }
}

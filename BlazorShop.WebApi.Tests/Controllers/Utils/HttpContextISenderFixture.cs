// <copyright file="HttpContextISenderFixture.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace BlazorShop.WebApi.Tests.Controllers.Utils
{
    /// <summary>
    /// A fixture class to help setup HttpContext for injecting the ISender (MediatR).
    /// </summary>
    public class HttpContextISenderFixture : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpContextISenderFixture"/> class.
        /// </summary>
        public HttpContextISenderFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            this.ServiceProvider = serviceCollection.BuildServiceProvider();

            this.HttpContextAccessor = this.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            this.Mediator = this.ServiceProvider.GetRequiredService<ISender>();

            var httpContext = new DefaultHttpContext
            {
                RequestServices = this.ServiceProvider,
            };

            this.HttpContextAccessor.HttpContext = httpContext;
        }

        /// <summary>
        /// Gets or sets the instance of <see cref="IHttpContextAccessor"/> to use.
        /// </summary>
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        /// <summary>
        /// Gets or sets the instance of <see cref="ISender"/> to use.
        /// </summary>
        public ISender Mediator { get; set; }

        /// <summary>
        /// Gets the instance of <see cref="Microsoft.Extensions.DependencyInjection.ServiceProvider"/> to use.
        /// </summary>
        private ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Ensure garbage collector for service provider.
        /// </summary>
        public void Dispose()
        {
            this.ServiceProvider.Dispose();
        }
    }
}

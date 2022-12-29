// <copyright file="DependencyInjection.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/> at Application level.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Make service modules available to the application level via dependancy injection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> instance to use.</param>
        /// <returns>The services collection.</returns>
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}

namespace BlazorShop.UnitOfWork
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWorkLayer(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWorkPattern>();
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<ISubscriberRepository, SubscriberRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();

            services.AddTransient<IMusicService, MusicService >();
            services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();

            return services;
        }
    }
}

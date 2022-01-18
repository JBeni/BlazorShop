namespace BlazorShop.UnitOfWork
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWorkLayer(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWorkPattern>();
            services.AddTransient<IMusicRepository, MusicRepository>();

            services.AddScoped<MusicService>();

            return services;
        }
    }
}

namespace BlazorShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration["ConnectionStrings:WebApiConnection"],
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

            // Inject services

            //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();

            var builder = services.AddIdentityCore<AppUser>(opt =>
            {
                // configure password options & others
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequiredUniqueChars = 1;
                opt.User.RequireUniqueEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, builder.RoleType, builder.Services);
            builder.AddRoles<AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthorizationCore(config =>
            {
                config.AddPolicy("Admin", policy => policy.RequireRole(ClaimTypes.Role, "Admin"));
                config.AddPolicy("User", policy => policy.RequireRole(ClaimTypes.Role, "User"));
                config.AddPolicy("Default", policy => policy.RequireRole(ClaimTypes.Role, "Default"));
            });

            return services;
        }
    }
}

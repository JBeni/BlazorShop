// <copyright file="DependencyInjection.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Infrastructure.Files;

namespace BlazorShop.Infrastructure
{
    /// <summary>
    /// Extension methods on <see cref="IServiceCollection"/> at Infrastructure level.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Make service modules available to the infrastructure level via dependancy injection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> instance to use.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance to use.</param>
        /// <returns>The services collection.</returns>
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration["ConnectionStrings:WebApiConnection"],
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Inject services
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IClaimService, ClaimService>();

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            var builder = services.AddIdentityCore<User>(opt =>
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
            builder.AddRoles<Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(StringRoleResources.Admin, policy => policy.RequireRole(ClaimTypes.Role, StringRoleResources.Admin));
                config.AddPolicy(StringRoleResources.User, policy => policy.RequireRole(ClaimTypes.Role, StringRoleResources.User));
                config.AddPolicy(StringRoleResources.Default, policy => policy.RequireRole(ClaimTypes.Role, StringRoleResources.Default));
            });

            return services;
        }
    }
}

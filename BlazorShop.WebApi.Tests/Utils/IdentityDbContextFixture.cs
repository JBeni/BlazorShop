// <copyright file="IdentityDbContextFixture.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Infrastructure.Persistence;

namespace BlazorShop.WebApi.Tests.Utils
{
    /// <summary>
    /// A fixture class to help setup IdentityDbContext.
    /// </summary>
    public class IdentityDbContextFixture : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityDbContextFixture"/> class.
        /// </summary>
        public IdentityDbContextFixture()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ApplicationDbContextTestDb"));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Gets the instance of <see cref="Microsoft.Extensions.DependencyInjection.ServiceProvider"/> to use.
        /// </summary>
        private ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets the User Manager.
        /// </summary>
        /// <returns>An instance of the <see cref="UserManager{User}"/> to be used.</returns>
        public UserManager<User> GetUserManager()
        {
            return this.ServiceProvider.GetService<UserManager<User>>();
        }

        /// <summary>
        /// Ensure garbage collector for service provider.
        /// </summary>
        public void Dispose()
        {
            this.ServiceProvider.Dispose();
        }
    }
}

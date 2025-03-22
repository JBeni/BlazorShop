// <copyright file="IdentityDbContextFixture.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// A test fixture for Identity database context tests.
    /// </summary>
    public class IdentityDbContextFixture : IDisposable
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityDbContextFixture"/> class.
        /// </summary>
        public IdentityDbContextFixture()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase($"BlazorShopIdentityTests_{Guid.NewGuid()}")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            Context = CreateContext();
            SeedTestData();
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        public ApplicationDbContext Context { get; private set; }

        /// <summary>
        /// Creates a new instance of the database context.
        /// </summary>
        /// <returns>A new instance of <see cref="ApplicationDbContext"/>.</returns>
        public ApplicationDbContext CreateContext()
        {
            var context = new ApplicationDbContext(_options);
            context.Database.EnsureCreated();
            return context;
        }

        /// <summary>
        /// Seeds the test data into the database.
        /// </summary>
        private void SeedTestData()
        {
            // Create test roles
            var roles = new[]
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
            };

            Context.Roles.AddRange(roles);

            // Create test users
            var hasher = new PasswordHasher<User>();
            var users = new[]
            {
                new User
                {
                    UserName = "testadmin",
                    NormalizedUserName = "TESTADMIN",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    IsActive = true,
                },
                new User
                {
                    UserName = "testuser",
                    NormalizedUserName = "TESTUSER",
                    Email = "user@test.com",
                    NormalizedEmail = "USER@TEST.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    IsActive = true,
                },
            };

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "Password123!");
                Context.Users.Add(user);
            }

            Context.SaveChanges();

            // Assign roles to users
            var userRoles = new[]
            {
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id, // Admin role
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles[1].Id, // User role
                },
            };

            Context.UserRoles.AddRange(userRoles);
            Context.SaveChanges();
        }

        /// <summary>
        /// Disposes the context and cleans up resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the context and cleans up resources.
        /// </summary>
        /// <param name="disposing">Whether to dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Database.EnsureDeleted();
                    Context.Dispose();
                }

                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Collection definition for Identity database context tests.
    /// </summary>
    [CollectionDefinition("IdentityDbContext Collection")]
    public class IdentityDbContextCollection : ICollectionFixture<IdentityDbContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
} 
// <copyright file="ApplicationDbContextSeedTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Domain.Entities;
using BlazorShop.Infrastructure.Identity;
using BlazorShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorShop.UnitTests.Infrastructure.Persistence
{
    /// <summary>
    /// Tests for <see cref="ApplicationDbContextSeed"/> class.
    /// </summary>
    public class ApplicationDbContextSeedTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<ILogger<ApplicationDbContextSeed>> _loggerMock;
        private readonly ApplicationDbContextSeed _seeder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContextSeedTests"/> class.
        /// </summary>
        public ApplicationDbContextSeedTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"BlazorShopSeedTest_{Guid.NewGuid()}")
                .Options;

            _context = new ApplicationDbContext(options);

            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                roleStore.Object, null, null, null, null);

            _loggerMock = new Mock<ILogger<ApplicationDbContextSeed>>();

            _seeder = new ApplicationDbContextSeed(
                _context,
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task SeedAsync_CreatesDefaultRoles()
        {
            // Arrange
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(false);
            _roleManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _seeder.SeedAsync();

            // Assert
            _roleManagerMock.Verify(x => x.CreateAsync(It.IsAny<IdentityRole>()), Times.AtLeast(2));
        }

        [Fact]
        public async Task SeedAsync_CreatesAdminUser()
        {
            // Arrange
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(x => x.AddToRolesAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _seeder.SeedAsync();

            // Assert
            _userManagerMock.Verify(x => x.CreateAsync(
                It.Is<ApplicationUser>(u => u.Email == "admin@localhost"),
                It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task SeedAsync_SeedsDefaultTodoList()
        {
            // Act
            await _seeder.SeedAsync();

            // Assert
            Assert.True(await _context.TodoLists.AnyAsync());
            var list = await _context.TodoLists.FirstOrDefaultAsync();
            Assert.NotNull(list);
            Assert.NotEmpty(list.Items);
        }

        [Fact]
        public async Task SeedAsync_DoesNotCreateDuplicateRoles()
        {
            // Arrange
            _roleManagerMock.Setup(x => x.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act
            await _seeder.SeedAsync();

            // Assert
            _roleManagerMock.Verify(x => x.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
        }

        [Fact]
        public async Task SeedAsync_DoesNotCreateDuplicateUsers()
        {
            // Arrange
            var existingUser = new ApplicationUser { Email = "admin@localhost" };
            _userManagerMock.Setup(x => x.FindByEmailAsync("admin@localhost"))
                .ReturnsAsync(existingUser);

            // Act
            await _seeder.SeedAsync();

            // Assert
            _userManagerMock.Verify(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task SeedAsync_LogsErrors()
        {
            // Arrange
            var error = new Exception("Seeding error");
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ThrowsAsync(error);

            // Act
            await _seeder.SeedAsync();

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.AtLeastOnce);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

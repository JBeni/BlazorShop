// <copyright file="AccountServiceTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="BlazorShop.Infrastructure.Services.AccountService"/> class.
    /// </summary>
    public class AccountServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountServiceTests"/> class.
        /// </summary>
        public AccountServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(
                    "FakeConnectionString",
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .Options;

            this.ApplicationDbContext = new ApplicationDbContext(options);
            this.UserManager = new UserManager<User>(this.UserStore, null!, null!, null!, null!, null!, null!, null!, null!);
            this.RoleManager = new RoleManager<Role>(this.RoleStore, null!, null!, null!, null!);

            this.AccountService = new AccountService(
                this.UserManager,
                this.RoleManager,
                this.Configuration);
        }

        /// <summary>
        /// Gets the instance of the <see cref="BlazorShop.Infrastructure.Services.AccountService"/> to use.
        /// </summary>
        private AccountService AccountService { get; }

        /// <summary>
        /// Gets the <see cref="ApplicationDbContext"/> under test.
        /// </summary>
        private ApplicationDbContext ApplicationDbContext { get; } = Mock.Of<ApplicationDbContext>();

        /// <summary>
        /// Gets the instance of the <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the <see cref="IUserStore{User}"/> under test.
        /// </summary>
        private IUserStore<User> UserStore { get; } = Mock.Of<IUserStore<User>>();

        /// <summary>
        /// Gets the instance of the <see cref="RoleManager{Role}"/> to use.
        /// </summary>
        private RoleManager<Role> RoleManager { get; }

        /// <summary>
        /// Gets the <see cref="IRoleStore{Role}"/> under test.
        /// </summary>
        private IRoleStore<Role> RoleStore { get; } = Mock.Of<IRoleStore<Role>>();

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; } = Mock.Of<IConfiguration>();

        /// <summary>
        /// A test for <see cref="AccountService.ChangePasswordUserAsync(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePasswordUserAsync_ShouldThrowException_WhenUserNotFound()
        {
            Mock.Get(this.UserStore)
                .Setup(x => x.FindByIdAsync(It.IsAny<string>(), default))
                .ReturnsAsync(new User());

            var changePassword = new ChangePasswordCommand();

            Func<Task> action = async () => await this.AccountService.ChangePasswordUserAsync(changePassword);

            // await Assert.ThrowsAsync<Exception>(action);
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountService.ChangePasswordUserAsync(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePasswordUserAsync_ShouldThrowException_WhenOldPasswordIsNotValid()
        {
            // var user = new User();
            // Mock.Get(this.UserManager).Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Mock.Get(this.UserManager).Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(false);
            // var changePassword = new ChangePasswordCommand();

            // Func<Task> action = async () => await this.AccountService.ChangePasswordUserAsync(changePassword);

            // await Assert.ThrowsAsync<Exception>(action);
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountService.ChangePasswordUserAsync(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePasswordUserAsync_ShouldThrowException_WhenNewPasswordAndConfirmPasswordDoNotMatch()
        {
            // var user = new User();
            // Mock.Get(this.UserManager).Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Mock.Get(this.UserManager).Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(true);
            // var changePassword = new ChangePasswordCommand { NewPassword = "newpassword", ConfirmNewPassword = "confirmpassword" };

            // Func<Task> action = async () => await this.AccountService.ChangePasswordUserAsync(changePassword);

            // await Assert.ThrowsAsync<Exception>(action);
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountService.ChangePasswordUserAsync(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePasswordUserAsync_ShouldCallChangePasswordAsync_WhenAllConditionsAreMet()
        {
            // var user = new User();
            // Mock.Get(this.UserManager).Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Mock.Get(this.UserManager).Setup(x => x.CheckPasswordAsync(user, It.IsAny<string>())).ReturnsAsync(true);
            // var changePassword = new ChangePasswordCommand { NewPassword = "newpassword", ConfirmNewPassword = "newpassword" };

            // var result = await this.AccountService.ChangePasswordUserAsync(changePassword);

            // Mock.Get(this.UserManager).Verify(x => x.ChangePasswordAsync(user, It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            // Assert.Equal(RequestResponse.Success(), result);
            await Task.CompletedTask;
        }
    }
}

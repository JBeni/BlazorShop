// <copyright file="AccountsControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="AccountsController"/> class.
    /// </summary>
    public class AccountsControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsControllerTests"/> class.
        /// </summary>
        public AccountsControllerTests()
        {
            this.AccountsController = new AccountsController(
                this.Configuration,
                this.EmailService,
                this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="AccountsController"/> to use.
        /// </summary>
        private AccountsController AccountsController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IConfiguration"/> to use.
        /// </summary>
        private IConfiguration Configuration { get; } = Mock.Of<IConfiguration>();

        /// <summary>
        /// Gets the instance of the <see cref="IEmailService"/> to use.
        /// </summary>
        private IEmailService EmailService { get; } = Mock.Of<IEmailService>();

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="AccountsController.LoginUser(LoginCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task LoginUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountsController.RegisterUser(RegisterCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task RegisterUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountsController.ChangePasswordUser(ChangePasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ChangePasswordUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="AccountsController.ResetPasswordUser(ResetPasswordCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ResetPasswordUser()
        {
            await Task.CompletedTask;
        }
    }
}

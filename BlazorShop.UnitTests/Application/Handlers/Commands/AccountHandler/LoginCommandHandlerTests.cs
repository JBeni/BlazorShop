// <copyright file="LoginCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="LoginCommandHandler"/> class.
    /// </summary>
    public class LoginCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginCommandHandlerTests"/> class.
        /// </summary>
        public LoginCommandHandlerTests()
        {
            this.SUT = new LoginCommandHandler(
                this.AccountService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="LoginCommandHandler"/> instance to use.
        /// </summary>
        private LoginCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

        /// <summary>
        /// Gets the <see cref="ILogger{LoginCommandHandler}"/> under test.
        /// </summary>
        private ILogger<LoginCommandHandler> Logger { get; } = Mock.Of<ILogger<LoginCommandHandler>>();

        /// <summary>
        /// A test for <see cref="LoginCommandHandler.Handle(LoginCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var loginCommand = Mock.Of<LoginCommand>(x =>
                x.Email == "test@gmail.com" &&
                x.Password == "test");

            var response = Mock.Of<JwtTokenResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.AccessToken == "nzxkcnkzxnckznxkcnkzxnckzxc-asdasdasdasd" &&
                x.Scope == "user:basic");

            Mock.Get(this.AccountService)
                .Setup(x => x.LoginAsync(loginCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(loginCommand, default);

            Mock.Get(this.AccountService)
                .Verify(x => x.LoginAsync(It.IsAny<LoginCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.AccessToken, response.AccessToken);
            Assert.Equal(result.Scope, response.Scope);
        }

        /// <summary>
        /// A test for <see cref="LoginCommandHandler.Handle(LoginCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<JwtTokenResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.LoginCommand);

            Mock.Get(this.AccountService)
                .Setup(x => x.LoginAsync(It.IsAny<LoginCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<LoginCommand>(), default);

            Mock.Get(this.AccountService)
                .Verify(x => x.LoginAsync(It.IsAny<LoginCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
            Assert.Null(result.AccessToken);
        }
    }
}

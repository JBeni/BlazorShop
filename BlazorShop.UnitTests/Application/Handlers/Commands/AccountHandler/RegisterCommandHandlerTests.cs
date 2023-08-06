// <copyright file="RegisterCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="RegisterCommandHandler"/> class.
    /// </summary>
    public class RegisterCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCommandHandlerTests"/> class.
        /// </summary>
        public RegisterCommandHandlerTests()
        {
            this.SUT = new RegisterCommandHandler(
                this.AccountService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="RegisterCommandHandler"/> instance to use.
        /// </summary>
        private RegisterCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

        /// <summary>
        /// Gets the <see cref="ILogger{RegisterCommandHandler}"/> under test.
        /// </summary>
        private ILogger<RegisterCommandHandler> Logger { get; } = Mock.Of<ILogger<RegisterCommandHandler>>();

        /// <summary>
        /// A test for <see cref="RegisterCommandHandler.Handle(RegisterCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var registerCommand = Mock.Of<RegisterCommand>(x =>
                x.Email == "test@gmail.com" &&
                x.Password == "test");

            var response = Mock.Of<JwtTokenResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.AccessToken == "nzxkcnkzxnckznxkcnkzxnckzxc-asdasdasdasd" &&
                x.Scope == "user:basic");

            Mock.Get(this.AccountService)
                .Setup(x => x.RegisterAsync(registerCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(registerCommand, default);

            Mock.Get(this.AccountService)
                .Verify(x => x.RegisterAsync(registerCommand), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.AccessToken, response.AccessToken);
            Assert.Equal(result.Scope, response.Scope);
        }

        /// <summary>
        /// A test for <see cref="RegisterCommandHandler.Handle(RegisterCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{JwtTokenResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<JwtTokenResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.RegisterCommand);

            Mock.Get(this.AccountService)
                .Setup(x => x.RegisterAsync(It.IsAny<RegisterCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<RegisterCommand>(), default);

            Mock.Get(this.AccountService)
                .Verify(x => x.RegisterAsync(It.IsAny<RegisterCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
            Assert.Null(result.AccessToken);
        }
    }
}

// <copyright file="ResetPasswordCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ResetPasswordCommandHandler"/> class.
    /// </summary>
    public class ResetPasswordCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandHandlerTests"/> class.
        /// </summary>
        public ResetPasswordCommandHandlerTests()
        {
            this.SUT = new ResetPasswordCommandHandler(
                this.AccountService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="ResetPasswordCommandHandler"/> instance to use.
        /// </summary>
        private ResetPasswordCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

        /// <summary>
        /// Gets the <see cref="ILogger{ResetPasswordCommandHandler}"/> under test.
        /// </summary>
        private ILogger<ResetPasswordCommandHandler> Logger { get; } = Mock.Of<ILogger<ResetPasswordCommandHandler>>();

        /// <summary>
        /// A test for <see cref="ResetPasswordCommandHandler.Handle(ResetPasswordCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var changePassCommand = Mock.Of<ResetPasswordCommand>(x =>
                x.NewPassword == "test" &&
                x.NewConfirmPassword == "test" &&
                x.Email == "test@test.com");

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.AccountService)
                .Setup(x => x.ResetPasswordUserAsync(changePassCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(changePassCommand, default);

            Mock.Get(this.AccountService)
                .Verify(x => x.ResetPasswordUserAsync(changePassCommand), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="ResetPasswordCommandHandler.Handle(ResetPasswordCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.ResetPasswordCommand &&
                x.EntityId == 0);

            Mock.Get(this.AccountService)
                .Setup(x => x.ResetPasswordUserAsync(It.IsAny<ResetPasswordCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<ResetPasswordCommand>(), default);

            Mock.Get(this.AccountService)
                .Verify(x => x.ResetPasswordUserAsync(It.IsAny<ResetPasswordCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

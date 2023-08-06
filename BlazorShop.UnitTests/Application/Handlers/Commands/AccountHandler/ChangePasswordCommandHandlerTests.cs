// <copyright file="ChangePasswordCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.AccountHandler
{
    /// <summary>
    /// Tests for <see cref="ChangePasswordCommandHandler"/> class.
    /// </summary>
    public class ChangePasswordCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandHandlerTests"/> class.
        /// </summary>
        public ChangePasswordCommandHandlerTests()
        {
            this.SUT = new ChangePasswordCommandHandler(
                this.AccountService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="ChangePasswordCommandHandler"/> instance to use.
        /// </summary>
        private ChangePasswordCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IAccountService"/> to use.
        /// </summary>
        private IAccountService AccountService { get; } = Mock.Of<IAccountService>();

        /// <summary>
        /// Gets the <see cref="ILogger{ChangePasswordCommandHandler}"/> under test.
        /// </summary>
        private ILogger<ChangePasswordCommandHandler> Logger { get; } = Mock.Of<ILogger<ChangePasswordCommandHandler>>();

        /// <summary>
        /// A test for <see cref="ChangePasswordCommandHandler.Handle(ChangePasswordCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var changePassCommand = Mock.Of<ChangePasswordCommand>(x =>
                x.NewPassword == "test" &&
                x.ConfirmNewPassword == "test" &&
                x.OldPassword == "test 1" &&
                x.UserId == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.AccountService)
                .Setup(x => x.ChangePasswordUserAsync(changePassCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(changePassCommand, default);

            Mock.Get(this.AccountService)
                .Verify(x => x.ChangePasswordUserAsync(It.IsAny<ChangePasswordCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="ChangePasswordCommandHandler.Handle(ChangePasswordCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.ChangePasswordCommand &&
                x.EntityId == 0);

            Mock.Get(this.AccountService)
                .Setup(x => x.ChangePasswordUserAsync(It.IsAny<ChangePasswordCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<ChangePasswordCommand>(), default);

            Mock.Get(this.AccountService)
                .Verify(x => x.ChangePasswordUserAsync(It.IsAny<ChangePasswordCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

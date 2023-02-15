// <copyright file="UpdateUserEmailCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserEmailCommandHandler"/> class.
    /// </summary>
    public class UpdateUserEmailCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserEmailCommandHandlerTests()
        {
            this.SUT = new UpdateUserEmailCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="UpdateUserEmailCommandHandler"/> instance to use.
        /// </summary>
        private UpdateUserEmailCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{UpdateUserEmailCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateUserEmailCommandHandler> Logger { get; } = Mock.Of<ILogger<UpdateUserEmailCommandHandler>>();

        /// <summary>
        /// A test for <see cref="UpdateUserEmailCommandHandler.Handle(UpdateUserEmailCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var updateUserEmailCommand = Mock.Of<UpdateUserEmailCommand>(x => x.Email == "test");

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.UpdateUserEmailAsync(updateUserEmailCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(updateUserEmailCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.UpdateUserEmailAsync(It.IsAny<UpdateUserEmailCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="UpdateUserEmailCommandHandler.Handle(UpdateUserEmailCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.UpdateUserEmailCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.UpdateUserEmailAsync(It.IsAny<UpdateUserEmailCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<UpdateUserEmailCommand>(), default);

            Mock.Get(this.UserService)
                .Verify(x => x.UpdateUserEmailAsync(It.IsAny<UpdateUserEmailCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

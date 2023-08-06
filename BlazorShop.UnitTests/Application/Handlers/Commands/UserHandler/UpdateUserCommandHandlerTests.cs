// <copyright file="UpdateUserCommandHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="UpdateUserCommandHandler"/> class.
    /// </summary>
    public class UpdateUserCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCommandHandlerTests"/> class.
        /// </summary>
        public UpdateUserCommandHandlerTests()
        {
            this.SUT = new UpdateUserCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="UpdateUserCommandHandler"/> instance to use.
        /// </summary>
        private UpdateUserCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{UpdateUserCommandHandler}"/> under test.
        /// </summary>
        private ILogger<UpdateUserCommandHandler> Logger { get; } = Mock.Of<ILogger<UpdateUserCommandHandler>>();

        /// <summary>
        /// A test for <see cref="UpdateUserCommandHandler.Handle(UpdateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var updateUserCommand = Mock.Of<UpdateUserCommand>(x => x.Id == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.UpdateUserAsync(updateUserCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(updateUserCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.UpdateUserAsync(It.IsAny<UpdateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="UpdateUserCommandHandler.Handle(UpdateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.UpdateUserCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.UpdateUserAsync(It.IsAny<UpdateUserCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<UpdateUserCommand>(), default);

            Mock.Get(this.UserService)
                .Verify(x => x.UpdateUserAsync(It.IsAny<UpdateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

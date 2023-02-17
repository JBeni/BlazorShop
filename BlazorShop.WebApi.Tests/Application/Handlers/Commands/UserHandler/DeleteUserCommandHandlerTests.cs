// <copyright file="DeleteUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="DeleteUserCommandHandler"/> class.
    /// </summary>
    public class DeleteUserCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandHandlerTests"/> class.
        /// </summary>
        public DeleteUserCommandHandlerTests()
        {
            this.SUT = new DeleteUserCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="DeleteUserCommandHandler"/> instance to use.
        /// </summary>
        private DeleteUserCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{DeleteUserCommandHandler}"/> under test.
        /// </summary>
        private ILogger<DeleteUserCommandHandler> Logger { get; } = Mock.Of<ILogger<DeleteUserCommandHandler>>();

        /// <summary>
        /// A test for <see cref="DeleteUserCommandHandler.Handle(DeleteUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle()
        {
            var deleteUserCommand = Mock.Of<DeleteUserCommand>(x => x.Id == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.DeleteUserAsync(deleteUserCommand.Id))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(deleteUserCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.DeleteUserAsync(It.IsAny<int>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="DeleteUserCommandHandler.Handle(DeleteUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var deleteUserCommand = Mock.Of<DeleteUserCommand>(x => x.Id == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.DeleteUserCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.DeleteUserAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(deleteUserCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.DeleteUserAsync(It.IsAny<int>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

// <copyright file="ActivateUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.UserHandler;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="ActivateUserCommandHandler"/> class.
    /// </summary>
    public class ActivateUserCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivateUserCommandHandlerTests"/> class.
        /// </summary>
        public ActivateUserCommandHandlerTests()
        {
            this.SUT = new ActivateUserCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="ActivateUserCommandHandler"/> instance to use.
        /// </summary>
        private ActivateUserCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{ActivateUserCommandHandler}"/> under test.
        /// </summary>
        private ILogger<ActivateUserCommandHandler> Logger { get; } = Mock.Of<ILogger<ActivateUserCommandHandler>>();

        /// <summary>
        /// A test for <see cref="ActivateUserCommandHandler.Handle(ActivateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var activateUserCommand = Mock.Of<ActivateUserCommand>(x => x.Id == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.ActivateUserAsync(activateUserCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(activateUserCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.ActivateUserAsync(It.IsAny<ActivateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
            Assert.Equal(result.EntityId, response.EntityId);
        }

        /// <summary>
        /// A test for <see cref="ActivateUserCommandHandler.Handle(ActivateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.ActivateUserCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.ActivateUserAsync(It.IsAny<ActivateUserCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<ActivateUserCommand>(), default);

            Mock.Get(this.UserService)
                .Verify(x => x.ActivateUserAsync(It.IsAny<ActivateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
            Assert.Equal(result.EntityId, response.EntityId);
        }
    }
}

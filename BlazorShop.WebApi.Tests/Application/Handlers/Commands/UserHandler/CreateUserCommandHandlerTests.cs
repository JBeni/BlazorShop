// <copyright file="CreateUserCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.UserHandler;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    public class CreateUserCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandlerTests"/> class.
        /// </summary>
        public CreateUserCommandHandlerTests()
        {
            this.SUT = new CreateUserCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="CreateUserCommandHandler"/> instance to use.
        /// </summary>
        private CreateUserCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{CreateUserCommandHandler}"/> under test.
        /// </summary>
        private ILogger<CreateUserCommandHandler> Logger { get; } = Mock.Of<ILogger<CreateUserCommandHandler>>();

        /// <summary>
        /// A test for <see cref="CreateUserCommandHandler.Handle(CreateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var createUserCommand = Mock.Of<CreateUserCommand>(x =>
                x.FirstName == "First" &&
                x.LastName == "Last");

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.CreateUserAsync(createUserCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(createUserCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.CreateUserAsync(It.IsAny<CreateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="CreateUserCommandHandler.Handle(CreateUserCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.CreateUserCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.CreateUserAsync(It.IsAny<CreateUserCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<CreateUserCommand>(), default);

            Mock.Get(this.UserService)
                .Verify(x => x.CreateUserAsync(It.IsAny<CreateUserCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

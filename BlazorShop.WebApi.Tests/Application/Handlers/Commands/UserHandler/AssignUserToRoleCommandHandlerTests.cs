// <copyright file="AssignUserToRoleCommandHandlerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Handlers.Commands.UserHandler;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Application.Handlers.Commands.UserHandler
{
    /// <summary>
    /// Tests for <see cref="AssignUserToRoleCommandHandler"/> class.
    /// </summary>
    public class AssignUserToRoleCommandHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignUserToRoleCommandHandlerTests"/> class.
        /// </summary>
        public AssignUserToRoleCommandHandlerTests()
        {
            this.SUT = new AssignUserToRoleCommandHandler(
                this.UserService,
                this.Logger);
        }

        /// <summary>
        /// Gets the <see cref="AssignUserToRoleCommandHandler"/> instance to use.
        /// </summary>
        private AssignUserToRoleCommandHandler SUT { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IUserService"/> to use.
        /// </summary>
        private IUserService UserService { get; } = Mock.Of<IUserService>();

        /// <summary>
        /// Gets the <see cref="ILogger{AssignUserToRoleCommandHandler}"/> under test.
        /// </summary>
        private ILogger<AssignUserToRoleCommandHandler> Logger { get; } = Mock.Of<ILogger<AssignUserToRoleCommandHandler>>();

        /// <summary>
        /// A test for <see cref="AssignUserToRoleCommandHandler.Handle(AssignUserToRoleCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle()
        {
            var assignUserToRoleCommand = Mock.Of<AssignUserToRoleCommand>(x =>
                x.UserId == new Random().Next() &&
                x.RoleId == new Random().Next());

            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == true &&
                x.Error == string.Empty &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.AssignUserToRoleAsync(assignUserToRoleCommand))
                .ReturnsAsync(response);

            var result = await this.SUT.Handle(assignUserToRoleCommand, default);

            Mock.Get(this.UserService)
                .Verify(x => x.AssignUserToRoleAsync(It.IsAny<AssignUserToRoleCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Equal(result.Error, response.Error);
        }

        /// <summary>
        /// A test for <see cref="AssignUserToRoleCommandHandler.Handle(AssignUserToRoleCommand, CancellationToken)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        [Fact]
        public async Task Handle_ThrowException()
        {
            var response = Mock.Of<RequestResponse>(x =>
                x.Successful == false &&
                x.Error == ErrorsManager.AssignUserToRoleCommand &&
                x.EntityId == 0);

            Mock.Get(this.UserService)
                .Setup(x => x.AssignUserToRoleAsync(It.IsAny<AssignUserToRoleCommand>()))
                .ThrowsAsync(new Exception());

            var result = await this.SUT.Handle(It.IsAny<AssignUserToRoleCommand>(), default);

            Mock.Get(this.UserService)
                .Verify(x => x.AssignUserToRoleAsync(It.IsAny<AssignUserToRoleCommand>()), Times.Once);

            Assert.Equal(result.Successful, response.Successful);
            Assert.Contains(response.Error, result.Error);
        }
    }
}

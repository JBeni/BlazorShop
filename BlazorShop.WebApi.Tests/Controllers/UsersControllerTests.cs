// <copyright file="UsersControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.WebApi.Controllers;
using Moq;
using Xunit;

namespace BlazorShop.WebApi.Tests.Controllers
{
    /// <summary>
    /// Tests for <see cref="UsersController"/> class.
    /// </summary>
    public class UsersControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersControllerTests"/> class.
        /// </summary>
        public UsersControllerTests()
        {
            this.UsersController = new UsersController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="UsersController"/> to use.
        /// </summary>
        private UsersController UsersController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="UsersController.CreateUser(CreateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task CreateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.ActivateUser(ActivateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task ActivateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.UpdateUser(UpdateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.UpdateUserEmail(UpdateUserEmailCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUserEmail()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.DeleteUser(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUser()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUserById(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserById()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUsers()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UsersController.GetUsersInactive()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsersInactive()
        {
            await Task.CompletedTask;
        }
    }
}

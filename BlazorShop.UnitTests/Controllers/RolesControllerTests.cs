// <copyright file="RolesControllerTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Controllers
{
    /// <summary>
    /// Tests for <see cref="RolesController"/> class.
    /// </summary>
    public class RolesControllerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesControllerTests"/> class.
        /// </summary>
        public RolesControllerTests()
        {
            this.RolesController = new RolesController(this.Mediator);
        }

        /// <summary>
        /// Gets the instance of the <see cref="RolesController"/> to use.
        /// </summary>
        private RolesController RolesController { get; }

        /// <summary>
        /// Gets the instance of the <see cref="IMediator"/> to use.
        /// </summary>
        private IMediator Mediator { get; } = Mock.Of<IMediator>();

        /// <summary>
        /// A test for <see cref="RolesController.CreateRole(CreateRoleCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RolesController.UpdateRole(UpdateRoleCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RolesController.DeleteRole(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RolesController.GetRoleById(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoleById()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RolesController.GetRoles()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoles()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RolesController.GetRolesForAdmin()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRolesForAdmin()
        {
            await Task.CompletedTask;
        }
    }
}

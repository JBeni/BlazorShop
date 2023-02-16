// <copyright file="UserServiceTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Tests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="UserService"/> class.
    /// </summary>
    public class UserServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserServiceTests"/> class.
        /// </summary>
        public UserServiceTests()
        {
            this.UserService = new UserService(
                this.UserManager,
                this.RoleService,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="UserService"/> to use.
        /// </summary>
        private UserService UserService { get; }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IRoleService"/> to use.
        /// </summary>
        private IRoleService RoleService { get; } = Mock.Of<IRoleService>();

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="UserService.CreateUserAsync(CreateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateUserAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.DeleteUserAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteUserAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.FindUserByEmailAsync(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task FindUserByEmailAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.FindUserByIdAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task FindUserByIdAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUserById(GetUserByIdQuery)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserById()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUserByEmail(GetUserByEmailQuery)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserByEmail()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUserRoleAsync(User)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserRoleAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.UpdateUserAsync(UpdateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUserAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.ActivateUserAsync(ActivateUserCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task ActivateUserAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.UpdateUserEmailAsync(UpdateUserEmailCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateUserEmailAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUsers(GetUsersQuery)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsers()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.GetUsersInactive(GetUsersInactiveQuery)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUsersInactive()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="UserService.AssignUserToRoleAsync(AssignUserToRoleCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task AssignUserToRoleAsync()
        {
            await Task.CompletedTask;
        }
    }
}

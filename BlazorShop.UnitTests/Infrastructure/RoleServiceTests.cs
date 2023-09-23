// <copyright file="RoleServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="RoleService"/> class.
    /// </summary>
    public class RoleServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleServiceTests"/> class.
        /// </summary>
        public RoleServiceTests()
        {
            this.RoleService = new RoleService(
                this.UserManager,
                this.RoleManager,
                this.Mapper);
        }

        /// <summary>
        /// Gets the instance of <see cref="RoleService"/> to use.
        /// </summary>
        private RoleService RoleService { get; }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="RoleManager{Role}"/> to use.
        /// </summary>
        private RoleManager<Role> RoleManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; } = Mock.Of<IMapper>();

        /// <summary>
        /// A test for <see cref="RoleService.CheckUserRolesAsync(User)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CheckUserRolesAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetDefaultRole()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetDefaultRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetUserRole()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetUserRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetAdminRole()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAdminRole()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.SetUserRoleAsync(User, string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task SetUserRoleAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRoles()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoles()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRolesForAdmin()"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRolesForAdmin()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRoleById(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoleById()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.GetRoleByNormalizedName(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetRoleByNormalizedName()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.CreateRoleAsync(CreateClaimCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task CreateRoleAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.UpdateRoleAsync(UpdateClaimCommand)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task UpdateRoleAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.DeleteRoleAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task DeleteRoleAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.FindRoleByIdAsync(int)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task FindRoleByIdAsync()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// A test for <see cref="RoleService.FindRoleByNameAsync(string)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task FindRoleByNameAsync()
        {
            await Task.CompletedTask;
        }
    }
}

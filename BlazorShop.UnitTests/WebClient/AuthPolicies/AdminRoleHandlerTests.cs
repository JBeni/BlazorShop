// <copyright file="AdminRoleHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.AuthPolicies
{
    /// <summary>
    /// Tests for <see cref="AdminRoleHandler"/> class.
    /// </summary>
    public class AdminRoleHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminRoleHandlerTests"/> class.
        /// </summary>
        public AdminRoleHandlerTests()
        {
            this.AdminRoleHandler = new AdminRoleHandler();
        }

        /// <summary>
        /// Gets the instance of the <see cref="AdminRoleHandler"/> to use.
        /// </summary>
        private AdminRoleHandler AdminRoleHandler { get; }

        /// <summary>
        /// Gets the instance of the <see cref="AuthorizationHandlerContext"/> to use.
        /// </summary>
        private AuthorizationHandlerContext AuthorizationHandlerContext { get; }

        /// <summary>
        /// A test for <see cref="AdminRoleHandler.HandleRequirementAsync(AuthorizationHandlerContext, AdminRoleRequirement)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task HandleRequirementAsync()
        {
            await Task.CompletedTask;
        }
    }
}

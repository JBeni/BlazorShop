// <copyright file="UserRoleHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.AuthPolicies
{
    /// <summary>
    /// Tests for <see cref="UserRoleHandler"/> class.
    /// </summary>
    public class UserRoleHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleHandlerTests"/> class.
        /// </summary>
        public UserRoleHandlerTests()
        {
            this.UserRoleHandler = new UserRoleHandler();
        }

        /// <summary>
        /// Gets the instance of the <see cref="UserRoleHandler"/> to use.
        /// </summary>
        private UserRoleHandler UserRoleHandler { get; }

        /// <summary>
        /// Gets the instance of the <see cref="AuthorizationHandlerContext"/> to use.
        /// </summary>
        private AuthorizationHandlerContext AuthorizationHandlerContext { get; }

        /// <summary>
        /// A test for <see cref="UserRoleHandler.HandleRequirementAsync(AuthorizationHandlerContext, UserRoleRequirement)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task HandleRequirementAsync()
        {
            await Task.CompletedTask;
        }
    }
}

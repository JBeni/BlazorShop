// <copyright file="DefaultRoleHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.AuthPolicies
{
    /// <summary>
    /// Tests for <see cref="DefaultRoleHandler"/> class.
    /// </summary>
    public class DefaultRoleHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRoleHandlerTests"/> class.
        /// </summary>
        public DefaultRoleHandlerTests()
        {
            this.DefaultRoleHandler = new DefaultRoleHandler();
        }

        /// <summary>
        /// Gets the instance of the <see cref="DefaultRoleHandler"/> to use.
        /// </summary>
        private DefaultRoleHandler DefaultRoleHandler { get; }

        /// <summary>
        /// Gets the instance of the <see cref="AuthorizationHandlerContext"/> to use.
        /// </summary>
        private AuthorizationHandlerContext AuthorizationHandlerContext { get; }

        /// <summary>
        /// A test for <see cref="DefaultRoleHandler.HandleRequirementAsync(AuthorizationHandlerContext, DefaultRoleRequirement)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task HandleRequirementAsync()
        {
            await Task.CompletedTask;
        }
    }
}

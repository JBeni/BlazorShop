// <copyright file="CustomerRoleHandlerTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.WebClient.AuthPolicies
{
    /// <summary>
    /// Tests for <see cref="CustomerRoleHandler"/> class.
    /// </summary>
    public class CustomerRoleHandlerTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRoleHandlerTests"/> class.
        /// </summary>
        public CustomerRoleHandlerTests()
        {
            this.CustomerRoleHandler = new CustomerRoleHandler();
        }

        /// <summary>
        /// Gets the instance of the <see cref="CustomerRoleHandler"/> to use.
        /// </summary>
        private CustomerRoleHandler CustomerRoleHandler { get; }

        /// <summary>
        /// Gets the instance of the <see cref="AuthorizationHandlerContext"/> to use.
        /// </summary>
        private AuthorizationHandlerContext AuthorizationHandlerContext { get; }

        /// <summary>
        /// A test for <see cref="CustomerRoleHandler.HandleRequirementAsync(AuthorizationHandlerContext, CustomerRoleRequirement)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task HandleRequirementAsync()
        {
            await Task.CompletedTask;
        }
    }
}

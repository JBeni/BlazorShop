// <copyright file="CustomerRoleHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// Handle the requirement of customer role.
    /// </summary>
    public class CustomerRoleHandler : AuthorizationHandler<CustomerRoleRequirement>
    {
        /// <summary>
        /// Search for the customer role.
        /// </summary>
        /// <param name="context">The instance of the <see cref="AuthorizationHandlerContext"/>.</param>
        /// <param name="requirement">The instance of the <see cref="UserRoleRequirement"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRoleRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var defaultRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Default);
                var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.User);

                if (userRole != null && userRole.Value.Equals(StringRoleResources.User))
                {
                    context.Succeed(requirement);
                }
                else if (defaultRole != null && defaultRole.Value.Equals(StringRoleResources.Default))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}

// <copyright file="AdminRoleHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// Handle the requirement of admin role.
    /// </summary>
    public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
    {
        /// <summary>
        /// Search for the admin role.
        /// </summary>
        /// <param name="context">The instance of the <see cref="AuthorizationHandlerContext"/>.</param>
        /// <param name="requirement">The instance of the <see cref="UserRoleRequirement"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Admin);

                if (userRole != null && userRole.Value.Equals(requirement.Role))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}

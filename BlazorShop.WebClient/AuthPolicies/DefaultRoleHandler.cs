// <copyright file="DefaultRoleHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// Handle the requirement of default role.
    /// </summary>
    public class DefaultRoleHandler : AuthorizationHandler<DefaultRoleRequirement>
    {
        /// <summary>
        /// Search for the default role.
        /// </summary>
        /// <param name="context">The instance of the <see cref="AuthorizationHandlerContext"/>.</param>
        /// <param name="requirement">The instance of the <see cref="UserRoleRequirement"/>.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DefaultRoleRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Default);

                if (userRole != null && userRole.Value.Equals(requirement.Role))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}

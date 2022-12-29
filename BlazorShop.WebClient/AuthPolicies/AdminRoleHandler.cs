// <copyright file="AdminRoleRequirement.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Admin role.
    /// </summary>
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public AdminRoleRequirement(string role)
        {
            Role = role;
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="todoItem">.</param>
    /// <returns></returns>
    public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
    {
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

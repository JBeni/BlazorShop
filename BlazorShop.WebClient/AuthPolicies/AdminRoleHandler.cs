// <copyright file="AdminRoleRequirement.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="todoItem">.</param>
    /// <returns></returns>
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
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Admin);
            if (userRole == null) return Task.CompletedTask;

            if (userRole.Value.Equals(requirement.Role))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}

// <copyright file="UserRoleRequirement.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the User role.
    /// </summary>
    public class UserRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public UserRoleRequirement(string role)
        {
            Role = role;
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="todoItem">.</param>
    /// <returns></returns>
    public class UserRoleHandler : AuthorizationHandler<UserRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.User);
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

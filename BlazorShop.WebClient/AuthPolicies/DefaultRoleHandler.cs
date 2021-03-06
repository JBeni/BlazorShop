// <copyright file="DefaultRoleRequirement.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Default role.
    /// </summary>
    public class DefaultRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public DefaultRoleRequirement(string role)
        {
            Role = role;
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="todoItem">.</param>
    /// <returns></returns>
    public class DefaultRoleHandler : AuthorizationHandler<DefaultRoleRequirement>
    {
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

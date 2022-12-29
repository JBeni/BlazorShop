// <copyright file="CustomerRoleRequirement.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.AuthPolicies
{
    /// <summary>
    /// A custom policy to check for the Customer role.
    /// </summary>
    public class CustomerRoleRequirement : IAuthorizationRequirement
    {
        public CustomerRoleRequirement()
        {
        }
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="todoItem">.</param>
    /// <returns></returns>
    public class CustomerRoleHandler : AuthorizationHandler<CustomerRoleRequirement>
    {
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

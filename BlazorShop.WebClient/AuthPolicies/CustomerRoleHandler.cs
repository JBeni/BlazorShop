namespace BlazorShop.WebClient.AuthPolicies
{
    public class CustomerRoleRequirement : IAuthorizationRequirement
    {
        public CustomerRoleRequirement()
        {
        }
    }

    public class CustomerRoleHandler : AuthorizationHandler<CustomerRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRoleRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var defaultRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Default);
            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.User);

            if (userRole == null && defaultRole == null) return Task.CompletedTask;

            if (userRole != null)
            {
                if (userRole.Value.Equals(StringRoleResources.User))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            if (defaultRole != null)
            {
                if (defaultRole.Value.Equals(StringRoleResources.Default))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}

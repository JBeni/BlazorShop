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

            var defaultRole = context.User.Claims.FirstOrDefault(c => c.Type == "role" && c.Value == "Default");
            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "role" && c.Value == "User");

            if (userRole == null && defaultRole == null) return Task.CompletedTask;

            if (userRole.Value.Equals("User") || defaultRole.Value.Equals("Default"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}

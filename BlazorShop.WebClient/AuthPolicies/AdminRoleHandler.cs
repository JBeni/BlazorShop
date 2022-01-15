namespace BlazorShop.WebClient.AuthPolicies
{
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public AdminRoleRequirement(string role)
        {
            Role = role;
        }
    }

    public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "role" && c.Value == "Admin");
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

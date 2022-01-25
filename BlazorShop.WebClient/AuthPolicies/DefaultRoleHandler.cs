namespace BlazorShop.WebClient.AuthPolicies
{
    public class DefaultRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public DefaultRoleRequirement(string role)
        {
            Role = role;
        }
    }

    public class DefaultRoleHandler : AuthorizationHandler<DefaultRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DefaultRoleRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == StringRoleResources.RoleClaim && c.Value == StringRoleResources.Default);
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

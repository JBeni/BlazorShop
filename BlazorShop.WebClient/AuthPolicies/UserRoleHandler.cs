namespace BlazorShop.WebClient.AuthPolicies
{
    public class UserRoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; }

        public UserRoleRequirement(string role)
        {
            Role = role;
        }
    }

    public class UserRoleHandler : AuthorizationHandler<UserRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) return Task.CompletedTask;

            var userRole = context.User.Claims.FirstOrDefault(c => c.Type == "role" && c.Value == "User");
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

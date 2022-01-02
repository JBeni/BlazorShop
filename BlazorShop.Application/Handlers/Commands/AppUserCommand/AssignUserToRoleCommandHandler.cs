namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AssignUserToRoleCommandHandler(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                var userRole = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRoleAsync(user, userRole[0]);

                var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, role.Name);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}

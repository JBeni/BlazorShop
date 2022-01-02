namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;
        private readonly IAppRoleService _AppRoleService;
        private readonly RoleManager<AppRole> _roleManager;

        public AssignUserToRoleCommandHandler(IAppUserService AppUserService,
                                              IAppRoleService AppRoleService,
                                              RoleManager<AppRole> roleManager)
        {
            _AppUserService = AppUserService;
            _AppRoleService = AppRoleService;
            _roleManager = roleManager;
        }

        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _AppUserService.FindUserByIdAsync(request.UserId);
                var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
                return await _AppRoleService.SetUserRoleAsync(user, role.Name);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;
        private readonly IAppRoleService _AppRoleService;
        public AssignUserToRoleCommandHandler(IAppUserService AppUserService, IAppRoleService AppRoleService)
        {
            _AppUserService = AppUserService;
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //return await _AppRoleService.SetUserRoleAsync(request);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }

}

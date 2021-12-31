namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class RemovenUserFromRoleCommandHandler : IRequestHandler<RemoveUserFromRoleCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;
        private readonly IAppRoleService _AppRoleService;
        public RemovenUserFromRoleCommandHandler(IAppUserService AppUserService, IAppRoleService AppRoleService)
        {
            _AppUserService = AppUserService;
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(RemoveUserFromRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //return await _AppRoleService.DeleteUserRolesAsync(request);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}

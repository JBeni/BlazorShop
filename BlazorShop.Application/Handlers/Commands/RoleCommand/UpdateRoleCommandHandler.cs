namespace BlazorShop.Application.Handlers.Commands.RoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _AppRoleService;

        public UpdateRoleCommandHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppRoleService.UpdateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the role", ex));
            }
        }
    }
}

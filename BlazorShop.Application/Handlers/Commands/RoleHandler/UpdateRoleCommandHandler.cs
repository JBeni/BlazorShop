namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleService.UpdateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the role", ex));
            }
        }
    }
}

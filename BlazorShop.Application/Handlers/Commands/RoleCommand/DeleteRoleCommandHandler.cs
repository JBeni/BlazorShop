namespace BlazorShop.Application.Handlers.Commands.RoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleService.DeleteRoleAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while deleting the role", ex));
            }
        }
    }
}

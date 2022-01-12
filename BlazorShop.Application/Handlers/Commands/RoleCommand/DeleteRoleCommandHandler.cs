namespace BlazorShop.Application.Handlers.Commands.RoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RequestResponse>
    {
        private readonly IRoleService _AppRoleService;

        public DeleteRoleCommandHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppRoleService.DeleteRoleAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while deleting the role", ex));
            }
        }
    }
}

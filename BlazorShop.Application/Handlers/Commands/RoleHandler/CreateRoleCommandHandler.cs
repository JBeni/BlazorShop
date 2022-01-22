namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _roleService.CreateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the role", ex));
            }
        }
    }
}

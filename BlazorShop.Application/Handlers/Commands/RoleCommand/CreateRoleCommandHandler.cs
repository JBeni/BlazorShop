namespace BlazorShop.Application.Handlers.Commands.RoleCommand
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _AppRoleService;

        public CreateRoleCommandHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppRoleService.CreateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the role", ex));
            }
        }
    }
}

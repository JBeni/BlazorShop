namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<CreateRoleCommandHandler> _logger;

        public CreateRoleCommandHandler(IRoleService roleService, ILogger<CreateRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogError(ex, "There was an error creating the role");
                return RequestResponse.Failure($"There was an error while creating the role. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

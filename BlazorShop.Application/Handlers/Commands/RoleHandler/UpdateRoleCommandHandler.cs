namespace BlazorShop.Application.Handlers.Commands.RoleHandler
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<UpdateRoleCommandHandler> _logger;

        public UpdateRoleCommandHandler(IRoleService roleService, ILogger<UpdateRoleCommandHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogError(ex, "There was an error updating the role");
                return RequestResponse.Error(new Exception("There was an error while updating the role", ex));
            }
        }
    }
}

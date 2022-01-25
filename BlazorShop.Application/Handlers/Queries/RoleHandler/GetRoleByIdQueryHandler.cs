namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByIdQueryHandler> _logger;

        public GetRoleByIdQueryHandler(IRoleService roleService, ILogger<GetRoleByIdQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoleById(request.Id);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the role by id...");
                return Task.FromResult(new RoleResponse
                {
                    Error = "There was an error getting the role by id... " + ex.Message ?? ex.InnerException.Message 
                });
            }
        }
    }
}

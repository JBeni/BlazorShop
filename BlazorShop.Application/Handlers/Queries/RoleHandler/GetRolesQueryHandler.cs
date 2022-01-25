namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesQueryHandler> _logger;

        public GetRolesQueryHandler(IRoleService roleService, ILogger<GetRolesQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<List<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoles();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the roles...");
                return Task.FromResult(new List<RoleResponse>
                {
                    new RoleResponse { Error = "There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message },
                });
            }
        }
    }
}

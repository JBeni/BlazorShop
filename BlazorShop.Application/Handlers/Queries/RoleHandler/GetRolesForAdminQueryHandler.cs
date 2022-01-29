namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRolesForAdminQueryHandler : IRequestHandler<GetRolesForAdminQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRolesQueryHandler> _logger;

        public GetRolesForAdminQueryHandler(IRoleService roleService, ILogger<GetRolesQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Result<RoleResponse>> Handle(GetRolesForAdminQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRolesForAdmin();

                return Task.FromResult(new Result<RoleResponse>
                {
                    Successful = true,
                    Items = result ?? new List<RoleResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the roles");
                return Task.FromResult(new Result<RoleResponse>
                {
                    Error = $"There was an error getting the roles. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

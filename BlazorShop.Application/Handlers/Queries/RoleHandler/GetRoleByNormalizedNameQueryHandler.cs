namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByNormalizedNameQueryHandler> _logger;

        public GetRoleByNormalizedNameQueryHandler(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Result<RoleResponse>> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoleByNormalizedName(request.NormalizedName);

                return Task.FromResult(new Result<RoleResponse>
                {
                    Successful = true,
                    Item = result ?? new RoleResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the role by normalized name");
                return Task.FromResult(new Result<RoleResponse>
                {
                    Error = $"There was an error getting the role by normalized name. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

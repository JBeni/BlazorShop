namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, RoleResponse>
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<GetRoleByNormalizedNameQueryHandler> _logger;

        public GetRoleByNormalizedNameQueryHandler(IRoleService roleService, ILogger<GetRoleByNormalizedNameQueryHandler> logger)
        {
            _roleService = roleService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<RoleResponse> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoleByNormalizedName(request.NormalizedName);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the role by normalized name...");
                return Task.FromResult(new RoleResponse
                {
                    Error = "There was an error getting the role by normalized name... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

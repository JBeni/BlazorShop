namespace BlazorShop.Application.Handlers.Queries.RoleHandler
{
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, RoleResponse>
    {
        private readonly IRoleService _roleService;

        public GetRoleByNormalizedNameQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleResponse> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoleByNormalizedName(request.NormalizedName);
                return result;
            }
            catch (Exception ex)
            {
                return new RoleResponse { Error = "There was an error getting the role by normalized name... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

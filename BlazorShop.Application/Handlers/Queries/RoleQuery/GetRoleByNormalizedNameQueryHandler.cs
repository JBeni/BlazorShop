namespace BlazorShop.Application.Handlers.Queries.RoleQuery
{
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, RoleResponse>
    {
        private readonly IRoleService _AppRoleService;

        public GetRoleByNormalizedNameQueryHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RoleResponse> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoleByNormalizedName(request.NormalizedName);
                return result;
            }
            catch (Exception ex)
            {
                return new RoleResponse { Error = "There was an error getting the role by normalized name... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

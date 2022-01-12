namespace BlazorShop.Application.Handlers.Queries.RoleQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleResponse>>
    {
        private readonly IRoleService _AppRoleService;

        public GetRolesQueryHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<List<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoles();
                return result;
            }
            catch (Exception ex)
            {
                return new List<RoleResponse>
                {
                    new RoleResponse { Error = "There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message },
                };
            }
        }
    }
}

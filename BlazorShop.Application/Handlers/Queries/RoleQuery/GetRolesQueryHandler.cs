namespace BlazorShop.Application.Handlers.Queries.RoleQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleResponse>>
    {
        private readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<List<RoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoles();
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

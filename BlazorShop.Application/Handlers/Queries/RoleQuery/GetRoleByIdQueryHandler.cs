namespace BlazorShop.Application.Handlers.Queries.RoleQuery
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly IRoleService _roleService;

        public GetRoleByIdQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _roleService.GetRoleById(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return new RoleResponse { Error = "There was an error getting the role by id... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

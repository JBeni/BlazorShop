namespace BlazorShop.Application.Handlers.Queries.RoleQuery
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly IRoleService _AppRoleService;

        public GetRoleByIdQueryHandler(IRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoleById(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return new RoleResponse { Error = "There was an error getting the role by id... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

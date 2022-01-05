namespace BlazorShop.Application.Handlers.Queries.AppRoleQuery
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<AppRoleResponse>>
    {
        private readonly IAppRoleService _AppRoleService;

        public GetRolesQueryHandler(IAppRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<List<AppRoleResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoles();
                return result;
            }
            catch (Exception ex)
            {
                return new List<AppRoleResponse>
                {
                    new AppRoleResponse { Error = "There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message },
                };
            }
        }
    }
}

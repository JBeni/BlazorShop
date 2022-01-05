namespace BlazorShop.Application.Handlers.Queries.AppRoleQuery
{
    public class GetRoleByNormalizedNameQueryHandler : IRequestHandler<GetRoleByNormalizedNameQuery, AppRoleResponse>
    {
        private readonly IAppRoleService _AppRoleService;

        public GetRoleByNormalizedNameQueryHandler(IAppRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<AppRoleResponse> Handle(GetRoleByNormalizedNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoleByNormalizedName(request.NormalizedName);
                return result;
            }
            catch (Exception ex)
            {
                return new AppRoleResponse { Error = "There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

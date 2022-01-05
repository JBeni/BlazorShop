namespace BlazorShop.Application.Handlers.Queries.AppRoleQuery
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, AppRoleResponse>
    {
        private readonly IAppRoleService _AppRoleService;

        public GetRoleByIdQueryHandler(IAppRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<AppRoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _AppRoleService.GetRoleById(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return new AppRoleResponse { Error = "There was an error getting the roles... " + ex.Message ?? ex.InnerException.Message };
            }
        }
    }
}

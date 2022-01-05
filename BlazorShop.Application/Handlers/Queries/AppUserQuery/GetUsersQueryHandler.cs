namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<AppUserResponse>>
    {
        private readonly IAppUserService _AppUserService;

        public GetUsersQueryHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public Task<List<AppUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_AppUserService.GetUsers(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<AppUserResponse>
                {
                    new AppUserResponse { Error = "There was an error getting the user... " + ex.Message ?? ex.InnerException.Message },
                });
            }
        }
    }
}

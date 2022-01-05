namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, AppUserResponse>
    {
        private readonly IAppUserService _AppUserService;

        public GetUserByEmailQueryHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public Task<AppUserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_AppUserService.GetUserByEmail(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new AppUserResponse
                {
                    Error = "There was an error getting the user by email... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

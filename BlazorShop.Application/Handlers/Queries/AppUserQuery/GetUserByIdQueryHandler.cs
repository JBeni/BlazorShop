namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AppUserResponse>
    {
        private readonly IAppUserService _AppUserService;

        public GetUserByIdQueryHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public Task<AppUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_AppUserService.GetUserById(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new AppUserResponse
                {
                    Error = "There was an error getting the user... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

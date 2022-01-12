namespace BlazorShop.Application.Handlers.Queries.UserQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserService _AppUserService;

        public GetUserByEmailQueryHandler(IUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_AppUserService.GetUserByEmail(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new UserResponse
                {
                    Error = "There was an error getting the user by email... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

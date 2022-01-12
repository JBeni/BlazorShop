namespace BlazorShop.Application.Handlers.Queries.UserQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserService _AppUserService;

        public GetUsersQueryHandler(IUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_AppUserService.GetUsers(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<UserResponse>
                {
                    new UserResponse { Error = "There was an error getting the users... " + ex.Message ?? ex.InnerException.Message },
                });
            }
        }
    }
}

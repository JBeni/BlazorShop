namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userService.GetUsers(request));
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

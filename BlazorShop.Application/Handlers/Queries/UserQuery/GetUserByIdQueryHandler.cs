namespace BlazorShop.Application.Handlers.Queries.UserQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userService.GetUserById(request));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new UserResponse
                {
                    Error = "There was an error getting the user by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

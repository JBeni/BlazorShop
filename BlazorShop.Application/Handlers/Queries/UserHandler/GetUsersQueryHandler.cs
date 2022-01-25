namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<List<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userService.GetUsers(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the users...");
                return Task.FromResult(new List<UserResponse>
                {
                    new UserResponse { Error = "There was an error getting the users... " + ex.Message ?? ex.InnerException.Message },
                });
            }
        }
    }
}

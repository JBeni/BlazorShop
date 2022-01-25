namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByEmailQueryHandler> _logger;

        public GetUserByEmailQueryHandler(IUserService userService, ILogger<GetUserByEmailQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userService.GetUserByEmail(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the user by email...");
                return Task.FromResult(new UserResponse
                {
                    Error = "There was an error getting the user by email... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

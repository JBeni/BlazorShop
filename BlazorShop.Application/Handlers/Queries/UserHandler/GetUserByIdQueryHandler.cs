namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserService userService, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_userService.GetUserById(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the user by id...");
                return Task.FromResult(new UserResponse
                {
                    Error = "There was an error getting the user by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

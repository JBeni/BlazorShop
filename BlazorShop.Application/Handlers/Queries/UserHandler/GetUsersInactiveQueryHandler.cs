namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUsersInactiveQueryHandler : IRequestHandler<GetUsersInactiveQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersInactiveQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Result<UserResponse>> Handle(GetUsersInactiveQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _userService.GetUsersInactive(request);

                return Task.FromResult(new Result<UserResponse>
                {
                    Successful = true,
                    Items = result ?? new List<UserResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the users");
                return Task.FromResult(new Result<UserResponse>
                {
                    Error = $"There was an error getting the inactive users. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

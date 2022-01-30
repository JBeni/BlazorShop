namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUsersQueryHandler> _logger;

        public GetUsersQueryHandler(IUserService userService, ILogger<GetUsersQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Result<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _userService.GetUsers(request);

                return Task.FromResult(new Result<UserResponse>
                {
                    Successful = true,
                    Items = result ?? new List<UserResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUsersQuery);
                return Task.FromResult(new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUsersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

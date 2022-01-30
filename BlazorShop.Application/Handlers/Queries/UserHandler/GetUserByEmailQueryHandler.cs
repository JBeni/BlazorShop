namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByEmailQueryHandler> _logger;

        public GetUserByEmailQueryHandler(IUserService userService, ILogger<GetUserByEmailQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<Result<UserResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _userService.GetUserByEmail(request);

                return Task.FromResult(new Result<UserResponse>
                {
                    Successful = true,
                    Item = result ?? new UserResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUserByEmailQuery);
                return Task.FromResult(new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUserByEmailQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

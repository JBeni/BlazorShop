namespace BlazorShop.Application.Handlers.Queries.UserHandler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserService userService, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _userService.GetUserById(request);

                return Task.FromResult(new Result<UserResponse>
                {
                    Successful = true,
                    Item = result ?? new UserResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUserByIdQuery);
                return Task.FromResult(new Result<UserResponse>
                {
                    Error = $"{ErrorsManager.GetUserByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

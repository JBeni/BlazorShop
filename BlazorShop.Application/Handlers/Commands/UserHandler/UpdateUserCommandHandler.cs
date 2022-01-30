namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserService userService, ILogger<UpdateUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateUserCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateUserCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

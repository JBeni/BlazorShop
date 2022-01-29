namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserService userService, ILogger<DeleteUserCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while deleting the user");
                return RequestResponse.Failure($"There was an error while deleting the user. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

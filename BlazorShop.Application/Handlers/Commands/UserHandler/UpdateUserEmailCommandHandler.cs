namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserEmailCommandHandler> _logger;

        public UpdateUserEmailCommandHandler(IUserService userService, ILogger<UpdateUserEmailCommandHandler> logger)
        {
            _userService = userService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateUserEmailAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while updating only the user email");
                return RequestResponse.Error(new Exception("There was an error while updating only the user email", ex));
            }
        }
    }
}

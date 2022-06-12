namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class AssignUserToRoleCommandHandler : IRequestHandler<AssignUserToRoleCommand, RequestResponse>
    {
        private readonly IUserService _userService;
        private readonly ILogger<AssignUserToRoleCommandHandler> _logger;

        public AssignUserToRoleCommandHandler(IUserService userService, ILogger<AssignUserToRoleCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(AssignUserToRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.AssignUserToRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.AssignUserToRoleCommand);
                return RequestResponse.Failure($"{ErrorsManager.AssignUserToRoleCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

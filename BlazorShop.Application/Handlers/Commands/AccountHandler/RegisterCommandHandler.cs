namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtTokenResponse>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(IAccountService accountService, ILogger<RegisterCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JwtTokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.RegisterAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.RegisterCommand);
                return JwtTokenResponse.Failure($"{ErrorsManager.RegisterCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

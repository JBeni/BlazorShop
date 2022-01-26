namespace BlazorShop.Application.Handlers.Commands.AccountHandler
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<ChangePasswordCommandHandler> _logger;

        public ChangePasswordCommandHandler(IAccountService accountService, ILogger<ChangePasswordCommandHandler> logger)
        {
            _accountService = accountService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.ChangePasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error changing the password");
                return RequestResponse.Error(new Exception("There was an error changing the password", ex));
            }
        }
    }
}

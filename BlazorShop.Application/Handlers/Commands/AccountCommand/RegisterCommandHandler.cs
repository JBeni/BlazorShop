namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtTokenResponse>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<JwtTokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.RegisterAsync(request);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error when the user tried to register", ex));
            }
        }
    }
}

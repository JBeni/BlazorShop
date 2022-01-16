namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenResponse>
    {
        private readonly IAccountService _accountService;

        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<JwtTokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.LoginAsync(request);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error when the user tried to log in", ex));
            }
        }
    }
}

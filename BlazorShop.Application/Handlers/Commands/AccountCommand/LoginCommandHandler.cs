namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenResponse>
    {
        private readonly IAccountService _AcountService;

        public LoginCommandHandler(IAccountService AcountService)
        {
            _AcountService = AcountService;
        }

        public async Task<JwtTokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AcountService.LoginAsync(request);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error when the user tried to log in", ex));
            }
        }
    }
}

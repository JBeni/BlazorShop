namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtTokenResponse>
    {
        private readonly IAccountService _AcountService;

        public RegisterCommandHandler(IAccountService AcountService)
        {
            _AcountService = AcountService;
        }

        public async Task<JwtTokenResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AcountService.RegisterAsync(request);
            }
            catch (Exception ex)
            {
                return JwtTokenResponse.Error(new Exception("There was an error register the user", ex));
            }
        }
    }
}

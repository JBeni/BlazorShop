namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, RequestResponse>
    {
        private readonly IAccountService _accountService;

        public ResetPasswordCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RequestResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.ResetPasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error resetting the password", ex));
            }
        }
    }
}

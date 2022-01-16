namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        private readonly IAccountService _accountService;

        public ChangePasswordCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RequestResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _accountService.ChangePasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error changing the password", ex));
            }
        }
    }
}

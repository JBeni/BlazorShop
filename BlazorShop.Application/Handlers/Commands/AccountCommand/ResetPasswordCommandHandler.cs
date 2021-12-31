namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, RequestResponse>
    {
        private readonly IAccountService _AcountService;

        public ResetPasswordCommandHandler(IAccountService AcountService)
        {
            _AcountService = AcountService;
        }

        public async Task<RequestResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AcountService.ResetPasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error resetting the password", ex));
            }
        }
    }
}

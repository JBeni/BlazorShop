namespace BlazorShop.Application.Handlers.Commands.AccountCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, RequestResponse>
    {
        private readonly IAccountService _AcountService;

        public ChangePasswordCommandHandler(IAccountService AcountService)
        {
            _AcountService = AcountService;
        }

        public async Task<RequestResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AcountService.ChangePasswordUserAsync(request);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error changing the password", ex));
            }
        }
    }
}

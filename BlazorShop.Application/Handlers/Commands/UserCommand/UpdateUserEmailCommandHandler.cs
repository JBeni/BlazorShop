namespace BlazorShop.Application.Handlers.Commands.UserCommand
{
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        private readonly IUserService _AppUserService;

        public UpdateUserEmailCommandHandler(IUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public async Task<RequestResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppUserService.UpdateUserEmailAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating only the user email", ex));
            }
        }
    }
}

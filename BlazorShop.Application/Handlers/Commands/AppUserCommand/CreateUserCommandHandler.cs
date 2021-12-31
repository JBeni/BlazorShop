namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;
        public CreateUserCommandHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public async Task<RequestResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AppUserService.CreateUserAsync(request);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

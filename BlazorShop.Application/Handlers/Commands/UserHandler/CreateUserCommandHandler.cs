namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.CreateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

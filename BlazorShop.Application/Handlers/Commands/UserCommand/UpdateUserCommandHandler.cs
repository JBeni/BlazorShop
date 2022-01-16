namespace BlazorShop.Application.Handlers.Commands.UserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}

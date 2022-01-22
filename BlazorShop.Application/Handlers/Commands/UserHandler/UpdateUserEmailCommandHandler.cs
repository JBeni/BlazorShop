namespace BlazorShop.Application.Handlers.Commands.UserHandler
{
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, RequestResponse>
    {
        private readonly IUserService _userService;

        public UpdateUserEmailCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.UpdateUserEmailAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating only the user email", ex));
            }
        }
    }
}

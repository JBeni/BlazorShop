namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;
        public DeleteUserCommandHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public async Task<RequestResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _AppUserService.DeleteUserAsync(request.Id);
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while deleting the user", ex));
            }
        }
    }
}

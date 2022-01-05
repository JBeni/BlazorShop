namespace BlazorShop.Application.Handlers.Commands.AppRoleCommand
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RequestResponse>
    {
        private readonly IAppRoleService _AppRoleService;

        public DeleteRoleCommandHandler(IAppRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppRoleService.DeleteRoleAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

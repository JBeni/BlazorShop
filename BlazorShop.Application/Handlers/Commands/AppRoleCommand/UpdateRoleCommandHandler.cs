namespace BlazorShop.Application.Handlers.Commands.AppRoleCommand
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RequestResponse>
    {
        private readonly IAppRoleService _AppRoleService;

        public UpdateRoleCommandHandler(IAppRoleService AppRoleService)
        {
            _AppRoleService = AppRoleService;
        }

        public async Task<RequestResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppRoleService.UpdateRoleAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

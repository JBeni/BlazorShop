namespace BlazorShop.Application.Handlers.Commands.AppRoleCommand
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RequestResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RequestResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(request.Name);
                if (role != null) throw new Exception("The role was already created");

                await _roleManager.CreateAsync(new AppRole
                {
                    Name = request.Name,
                    NormalizedName = request.Name.ToUpper()
                });
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

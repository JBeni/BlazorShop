namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RequestResponse>
    {
        private readonly UserManager<AppUser> _userManager;
         

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == request.Email);
                if (existUser != null) throw new Exception("The user with the unique identifier already exists");
                var newUser = new AppUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                };

                await _userManager.CreateAsync(newUser);
                if (request.Role.Length > 0)
                {
                    await _userManager.AddToRoleAsync(newUser, request.Role);
                }
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while creating the user", ex));
            }
        }
    }
}

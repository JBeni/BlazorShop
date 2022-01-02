namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class FindUserByEmailQueryHandler : IRequestHandler<FindUserByEmailQuery, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public FindUserByEmailQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> Handle(FindUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error getting the user... " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

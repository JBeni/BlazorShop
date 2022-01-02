namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class FindUserByIdQueryHandler : IRequestHandler<FindUserByIdQuery, AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public FindUserByIdQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error getting the user... " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

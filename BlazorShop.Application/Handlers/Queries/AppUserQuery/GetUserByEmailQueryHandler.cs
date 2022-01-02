namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, AppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<AppUserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.Users
                    .Where(x => x.Email == request.Email)
                    .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(user);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new AppUserResponse
                {
                    Error = "There was an error getting the user by email... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

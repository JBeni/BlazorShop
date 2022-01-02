namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<AppUserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<List<AppUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.Users
                    .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(user);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error getting the user... " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.AppUserQuery
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AppUserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<AppUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userManager.Users
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<AppUserResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(user);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new AppUserResponse
                {
                    Error = "There was an error getting the user... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

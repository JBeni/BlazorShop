namespace BlazorShop.Application.Handlers.Queries.UserJwtTokenQuery
{
    public class GetUserJwtTokenByUserIdQueryHandler : IRequestHandler<GetUserJwtTokenByUserIdQuery, UserJwtTokenResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserJwtTokenByUserIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<UserJwtTokenResponse> Handle(GetUserJwtTokenByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.UserJwtTokens
                    .Where(d => d.UserId == request.UserId)
                    .ProjectTo<UserJwtTokenResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new UserJwtTokenResponse
                {
                    Error = "There was an error while getting the user jwt token... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

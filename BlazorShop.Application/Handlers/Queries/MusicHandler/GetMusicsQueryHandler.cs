namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    public class GetMusicsQueryHandler : IRequestHandler<GetMusicsQuery, List<MusicResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMusicsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<MusicResponse>> Handle(GetMusicsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Musics
                    .ProjectTo<MusicResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<MusicResponse>
                {
                    new MusicResponse
                    {
                        Error = "There was an error while getting the musics... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

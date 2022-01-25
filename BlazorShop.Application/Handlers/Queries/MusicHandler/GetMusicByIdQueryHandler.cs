namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    public class GetMusicByIdQueryHandler : IRequestHandler<GetMusicByIdQuery, MusicResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetMusicByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetMusicByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetMusicByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<MusicResponse> Handle(GetMusicByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Musics
                    .ProjectTo<MusicResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the music by id...");
                return Task.FromResult(new MusicResponse
                {
                    Error = "There was an error while getting the music by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

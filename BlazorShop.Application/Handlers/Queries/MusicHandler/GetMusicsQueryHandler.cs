namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    public class GetMusicsQueryHandler : IRequestHandler<GetMusicsQuery, Result<MusicResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetMusicsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetMusicsQueryHandler(IApplicationDbContext dbContext, ILogger<GetMusicsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<MusicResponse>> Handle(GetMusicsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Musics
                    .ProjectTo<MusicResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<MusicResponse>
                {
                    Successful = true,
                    Items = result ?? new List<MusicResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the musics");
                return Task.FromResult(new Result<MusicResponse>
                {
                    Error = $"There was an error while getting the musics. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, List<ClotheResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetClothesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetClothesQueryHandler(IApplicationDbContext dbContext, ILogger<GetClothesQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<List<ClotheResponse>> Handle(GetClothesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Clothes
                    .Where(x => x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the clothes...");
                return Task.FromResult(new List<ClotheResponse>
                {
                    new ClotheResponse
                    {
                        Error = "There was an error while getting the clothes... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

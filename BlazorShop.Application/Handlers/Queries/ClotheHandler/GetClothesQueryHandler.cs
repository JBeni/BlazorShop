namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, Result<ClotheResponse>>
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

        public Task<Result<ClotheResponse>> Handle(GetClothesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Clothes
                    .Where(x => x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<ClotheResponse>
                {
                    Successful = true,
                    Items = result ?? new List<ClotheResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetClothesQuery);
                return Task.FromResult(new Result<ClotheResponse>
                {
                    Error = $"{ErrorsManager.GetClothesQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

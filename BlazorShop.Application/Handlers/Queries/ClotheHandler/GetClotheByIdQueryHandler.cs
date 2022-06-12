namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    public class GetClotheByIdQueryHandler : IRequestHandler<GetClotheByIdQuery, Result<ClotheResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetClotheByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetClotheByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetClotheByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<ClotheResponse>> Handle(GetClotheByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Clothes
                    .Where(x => x.Id == request.Id && x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<ClotheResponse>
                {
                    Successful = true,
                    Item = result ?? new ClotheResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetClotheByIdQuery);
                return Task.FromResult(new Result<ClotheResponse>
                {
                    Error = $"{ErrorsManager.GetClotheByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

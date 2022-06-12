namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    public class GetSubscribersQueryHandler : IRequestHandler<GetSubscribersQuery, Result<SubscriberResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetSubscribersQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSubscribersQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscribersQueryHandler> logger, IMapper mapper)
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
        public Task<Result<SubscriberResponse>> Handle(GetSubscribersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<SubscriberResponse>
                {
                    Successful = true,
                    Items = result ?? new List<SubscriberResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetSubscribersQuery);
                return Task.FromResult(new Result<SubscriberResponse>
                {
                    Error = $"{ErrorsManager.GetSubscribersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

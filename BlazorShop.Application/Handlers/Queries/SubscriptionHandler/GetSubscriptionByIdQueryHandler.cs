namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetSubscriptionByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSubscriptionByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriptionByIdQueryHandler> logger, IMapper mapper)
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
        public Task<Result<SubscriptionResponse>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscriptions
                    .ProjectTo<SubscriptionResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                return Task.FromResult(new Result<SubscriptionResponse>
                {
                    Successful = true,
                    Item = result ?? new SubscriptionResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetSubscriptionByIdQuery);
                return Task.FromResult(new Result<SubscriptionResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriptionByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

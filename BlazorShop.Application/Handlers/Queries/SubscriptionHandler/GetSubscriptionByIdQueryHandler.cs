namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionResponse>
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

        public Task<SubscriptionResponse> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscriptions
                    .ProjectTo<SubscriptionResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the subscription by id...");
                return Task.FromResult(new SubscriptionResponse
                {
                    Error = "There was an error while getting the subscription by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

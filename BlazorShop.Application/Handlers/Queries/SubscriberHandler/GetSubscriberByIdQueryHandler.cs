namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    public class GetSubscriberByIdQueryHandler : IRequestHandler<GetSubscriberByIdQuery, SubscriberResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetSubscriberByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSubscriberByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriberByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<SubscriberResponse> Handle(GetSubscriberByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.CustomerId == request.UserId && x.Status == SubscriptionStatus.Active);
                return Task.FromResult(result ?? new SubscriberResponse());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the subscriber by user id - active subscription...");
                return Task.FromResult(new SubscriberResponse
                {
                    Error = "There was an error while getting the subscriber by user id - active subscription... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

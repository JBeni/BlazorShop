namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    public class GetUserSubscribersQueryHandler : IRequestHandler<GetUserSubscribersQuery, Result<SubscriberResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetUserSubscribersQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetUserSubscribersQueryHandler(IApplicationDbContext dbContext, ILogger<GetUserSubscribersQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<SubscriberResponse>> Handle(GetUserSubscribersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .Where(x => x.Customer.Id == request.UserId && x.Status == SubscriptionStatus.Inactive)
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
                _logger.LogError(ex, "There was an error while getting the subscribers by user id");
                return Task.FromResult(new Result<SubscriberResponse>
                {
                    Error = $"There was an error while getting the subscribers by user id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, List<SubscriptionResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubscriptionsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<SubscriptionResponse>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscriptions
                    .ProjectTo<SubscriptionResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<SubscriptionResponse>
                {
                    new SubscriptionResponse
                    {
                        Error = "There was an error while getting the subscriptions... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

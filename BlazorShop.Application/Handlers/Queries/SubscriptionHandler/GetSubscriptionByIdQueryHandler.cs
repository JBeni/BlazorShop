namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubscriptionByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
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
                return Task.FromResult(new SubscriptionResponse
                {
                    Error = "There was an error while getting the subscription by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

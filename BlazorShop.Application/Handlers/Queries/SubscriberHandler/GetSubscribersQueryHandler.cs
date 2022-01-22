namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    public class GetSubscribersQueryHandler : IRequestHandler<GetSubscribersQuery, List<SubscriberResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubscribersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<SubscriberResponse>> Handle(GetSubscribersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new List<SubscriberResponse>
                {
                    new SubscriberResponse
                    {
                        Error = "There was an error while getting the subscribers... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

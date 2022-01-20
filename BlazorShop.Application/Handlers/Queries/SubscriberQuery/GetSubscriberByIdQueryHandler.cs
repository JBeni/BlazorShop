namespace BlazorShop.Application.Handlers.Queries.SubscriberQuery
{
    public class GetSubscriberByIdQueryHandler : IRequestHandler<GetSubscriberByIdQuery, SubscriberResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSubscriberByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<SubscriberResponse> Handle(GetSubscriberByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new SubscriberResponse
                {
                    Error = "There was an error while getting the subscriber by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

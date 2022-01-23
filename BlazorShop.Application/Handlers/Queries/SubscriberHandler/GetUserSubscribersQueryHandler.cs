﻿namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    public class GetUserSubscribersQueryHandler : IRequestHandler<GetUserSubscribersQuery, List<SubscriberResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserSubscribersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<SubscriberResponse>> Handle(GetUserSubscribersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Subscribers
                    .Where(x => x.Customer.Id == request.UserId && x.Status == SubscriptionStatus.Inactive)
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
                        Error = "There was an error while getting the subscribers by user id... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}
// <copyright file="GetUserSubscribersQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<SubscriberResponse>> Handle(GetUserSubscribersQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriberResponse>? response;

            try
            {
                var result = _dbContext.Subscribers
                    .TagWith(nameof(GetUserSubscribersQueryHandler))
                    .Where(x => x.Customer.Id == request.UserId && x.Status == SubscriptionStatus.Inactive)
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<SubscriberResponse>
                {
                    Successful = true,
                    Items = result ?? new List<SubscriberResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetUserSubscribersQuery);
                response = new Result<SubscriberResponse>
                {
                    Error = $"{ErrorsManager.GetUserSubscribersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

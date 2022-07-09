// <copyright file="GetSubscriptionsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, Result<SubscriptionResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetSubscriptionsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSubscriptionsQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriptionsQueryHandler> logger, IMapper mapper)
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
        public Task<Result<SubscriptionResponse>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriptionResponse>? response;

            try
            {
                var result = _dbContext.Subscriptions
                    .TagWith(nameof(GetSubscriptionsQueryHandler))
                    .ProjectTo<SubscriptionResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<SubscriptionResponse>
                {
                    Successful = true,
                    Items = result ?? new List<SubscriptionResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetSubscriptionsQuery);
                response = new Result<SubscriptionResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriptionsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

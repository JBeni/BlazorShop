// <copyright file="GetSubscriptionsQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetSubscriptionsQuery, Result{SubscriptionResponse}}"/>.
    /// </summary>
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, Result<SubscriptionResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetSubscriptionsQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetSubscriptionsQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetSubscriptionsQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetSubscriptionsQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriptionsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetSubscriptionsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{SubscriptionResponse}}"/>.</returns>
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

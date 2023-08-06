// <copyright file="GetSubscriptionsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetSubscriptionsQuery, SubscriptionResponse}"/>.
    /// </summary>
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, Result<SubscriptionResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetSubscriptionsQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetSubscriptionsQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriptionsQueryHandler> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetSubscriptionsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetSubscriptionsQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetSubscriptionsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{SubscriptionResponse}"/>.</returns>
        public Task<Result<SubscriptionResponse>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriptionResponse>? response;

            try
            {
                var result = this.DbContext.Subscriptions
                    .TagWith(nameof(GetSubscriptionsQueryHandler))
                    .ProjectTo<SubscriptionResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<SubscriptionResponse>
                {
                    Successful = true,
                    Items = result ?? new List<SubscriptionResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetSubscriptionsQuery);
                response = new Result<SubscriptionResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriptionsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

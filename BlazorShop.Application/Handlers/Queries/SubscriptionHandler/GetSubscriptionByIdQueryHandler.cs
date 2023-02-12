// <copyright file="GetSubscriptionByIdQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriptionHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetSubscriptionByIdQuery, SubscriptionResponse}"/>.
    /// </summary>
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetSubscriptionByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetSubscriptionByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriptionByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetSubscriptionByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetSubscriptionByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetSubscriptionByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{SubscriptionResponse}"/>.</returns>
        public Task<Result<SubscriptionResponse>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriptionResponse>? response;

            try
            {
                var result = this.DbContext.Subscriptions
                    .TagWith(nameof(GetSubscriptionByIdQueryHandler))
                    .ProjectTo<SubscriptionResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                response = new Result<SubscriptionResponse>
                {
                    Successful = true,
                    Item = result ?? new SubscriptionResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetSubscriptionByIdQuery);
                response = new Result<SubscriptionResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriptionByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

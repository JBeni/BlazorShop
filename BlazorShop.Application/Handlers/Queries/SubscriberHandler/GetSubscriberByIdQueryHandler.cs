// <copyright file="GetSubscriberByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetSubscriberByIdQuery, SubscriberResponse}"/>.
    /// </summary>
    public class GetSubscriberByIdQueryHandler : IRequestHandler<GetSubscriberByIdQuery, Result<SubscriberResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriberByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetSubscriberByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetSubscriberByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriberByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetSubscriberByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetSubscriberByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetSubscriberByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{SubscriberResponse}"/>.</returns>
        public Task<Result<SubscriberResponse>> Handle(GetSubscriberByIdQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriberResponse>? response;

            try
            {
                var result = this.DbContext.Subscribers
                    .TagWith(nameof(GetSubscriberByIdQueryHandler))
                    .ProjectTo<SubscriberResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.CustomerId == request.UserId && x.Status == SubscriptionStatus.Active);

                response = new Result<SubscriberResponse>
                {
                    Successful = true,
                    Item = result ?? new SubscriberResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetSubscriberByIdQuery);
                response = new Result<SubscriberResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriberByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

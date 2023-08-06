// <copyright file="GetSubscribersQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetSubscribersQuery, SubscriberResponse}"/>.
    /// </summary>
    public class GetSubscribersQueryHandler : IRequestHandler<GetSubscribersQuery, Result<SubscriberResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscribersQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetSubscribersQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetSubscribersQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscribersQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetSubscribersQueryHandler}"/>.
        /// </summary>
        private ILogger<GetSubscribersQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetSubscribersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{SubscriberResponse}"/>.</returns>
        public Task<Result<SubscriberResponse>> Handle(GetSubscribersQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriberResponse>? response;

            try
            {
                var result = this.DbContext.Subscribers
                    .TagWith(nameof(GetSubscribersQueryHandler))
                    .ProjectTo<SubscriberResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<SubscriberResponse>
                {
                    Successful = true,
                    Items = result ?? new List<SubscriberResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetSubscribersQuery);
                response = new Result<SubscriberResponse>
                {
                    Error = $"{ErrorsManager.GetSubscribersQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

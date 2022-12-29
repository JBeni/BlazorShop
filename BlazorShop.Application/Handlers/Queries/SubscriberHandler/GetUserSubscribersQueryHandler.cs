// <copyright file="GetUserSubscribersQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetUserSubscribersQuery, Result{SubscriberResponse}}"/>.
    /// </summary>
    public class GetUserSubscribersQueryHandler : IRequestHandler<GetUserSubscribersQuery, Result<SubscriberResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetUserSubscribersQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetUserSubscribersQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserSubscribersQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetUserSubscribersQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetUserSubscribersQueryHandler(IApplicationDbContext dbContext, ILogger<GetUserSubscribersQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetUserSubscribersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{SubscriberResponse}}"/>.</returns>
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

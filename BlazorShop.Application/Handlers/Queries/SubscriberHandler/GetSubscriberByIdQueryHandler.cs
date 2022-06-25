// <copyright file="GetSubscriberByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.SubscriberHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetSubscriberByIdQueryHandler : IRequestHandler<GetSubscriberByIdQuery, Result<SubscriberResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetSubscriberByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSubscriberByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetSubscriberByIdQueryHandler> logger, IMapper mapper)
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
        public Task<Result<SubscriberResponse>> Handle(GetSubscriberByIdQuery request, CancellationToken cancellationToken)
        {
            Result<SubscriberResponse>? response;

            try
            {
                var result = _dbContext.Subscribers
                    .TagWith(nameof(GetSubscriberByIdQueryHandler))
                    .ProjectTo<SubscriberResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.CustomerId == request.UserId && x.Status == SubscriptionStatus.Active);

                response = new Result<SubscriberResponse>
                {
                    Successful = true,
                    Item = result ?? new SubscriberResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetSubscriberByIdQuery);
                response = new Result<SubscriberResponse>
                {
                    Error = $"{ErrorsManager.GetSubscriberByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

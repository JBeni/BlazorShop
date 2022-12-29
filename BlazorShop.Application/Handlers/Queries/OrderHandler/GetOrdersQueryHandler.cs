// <copyright file="GetOrdersQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetOrdersQuery, Result{OrderResponse}}"/>.
    /// </summary>
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<OrderResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetOrdersQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetOrdersQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrdersQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetOrdersQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetOrdersQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrdersQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetOrdersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{OrderResponse}}"/>.</returns>
        public Task<Result<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Result<OrderResponse>? response;

            try
            {
                var result = _dbContext.Orders
                    .TagWith(nameof(GetOrdersQueryHandler))
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<OrderResponse>
                {
                    Successful = true,
                    Items = result ?? new List<OrderResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetOrdersQuery);
                response = new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrdersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

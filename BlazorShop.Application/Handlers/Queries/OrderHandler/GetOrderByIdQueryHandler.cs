// <copyright file="GetOrderByIdQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetOrderByIdQuery, Result{OrderResponse}}"/>.
    /// </summary>
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetOrderByIdQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetOrderByIdQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetOrderByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrderByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetOrderByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{OrderResponse}}"/>.</returns>
        public Task<Result<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Result<OrderResponse>? response;

            try
            {
                var result = _dbContext.Orders
                    .TagWith(nameof(GetOrderByIdQueryHandler))
                    .Where(d => d.Id == request.Id && d.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<OrderResponse>
                {
                    Successful = true,
                    Item = result ?? new OrderResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetOrderByIdQuery);
                response = new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrderByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

// <copyright file="GetOrderByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrderByIdQueryHandler> logger, IMapper mapper)
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

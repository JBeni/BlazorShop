// <copyright file="GetOrdersQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<OrderResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetOrdersQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrdersQueryHandler> logger, IMapper mapper)
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

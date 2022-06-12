﻿namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
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
            try
            {
                var result = _dbContext.Orders
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<OrderResponse>
                {
                    Successful = true,
                    Items = result ?? new List<OrderResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetOrdersQuery);
                return Task.FromResult(new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrdersQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

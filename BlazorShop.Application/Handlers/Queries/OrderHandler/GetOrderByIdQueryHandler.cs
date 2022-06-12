namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
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
            try
            {
                var result = _dbContext.Orders
                    .Where(d => d.Id == request.Id && d.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<OrderResponse>
                {
                    Successful = true,
                    Item = result ?? new OrderResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetOrderByIdQuery);
                return Task.FromResult(new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrderByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

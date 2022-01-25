namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderResponse>>
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

        public Task<List<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Orders
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the orders...");
                return Task.FromResult(new List<OrderResponse>
                {
                    new OrderResponse
                    {
                        Error = "There was an error while getting the orders... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

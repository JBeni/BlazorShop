namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
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

        public Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Orders
                    .Where(d => d.Id == request.Id && d.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the order by id...");
                return Task.FromResult(new OrderResponse
                {
                    Error = "There was an error while getting the order by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

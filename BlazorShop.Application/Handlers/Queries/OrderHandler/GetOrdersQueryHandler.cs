namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
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
                List<OrderResponse> ordersView = new();
                ordersView.Add(new OrderResponse
                {
                    Error = "There was an error while getting the orders... " + ex.Message ?? ex.InnerException.Message
                });
                return Task.FromResult(ordersView);
            }
        }
    }
}

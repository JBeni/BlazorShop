namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    public class GetOrderByUserEmailQueryHandler : IRequestHandler<GetOrderByUserEmailQuery, OrderResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderByUserEmailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<OrderResponse> Handle(GetOrderByUserEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Orders
                    .Where(d => d.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OrderResponse
                {
                    Error = "There was an error while getting the order by user email... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCartByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<CartResponse> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts
                    .Where(x => x.Id == request.Id && x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the cart by id...");
                return Task.FromResult(new CartResponse
                {
                    Error = "There was an error while getting the cart by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Result<CartResponse>>
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

        public Task<Result<CartResponse>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts
                    .Where(x => x.Id == request.Id && x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<CartResponse>
                {
                    Successful = true,
                    Item = result ?? new CartResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the cart by id");
                return Task.FromResult(new Result<CartResponse>
                {
                    Error = $"There was an error while getting the cart by id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

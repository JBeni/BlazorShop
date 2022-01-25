namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, List<CartResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCartsQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<List<CartResponse>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts
                    .Where(x => x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the carts... ");
                return Task.FromResult(new List<CartResponse>
                {
                    new CartResponse { Error = "There was an error while getting the carts... " + ex.Message ?? ex.InnerException.Message },
                });
            }
        }
    }
}

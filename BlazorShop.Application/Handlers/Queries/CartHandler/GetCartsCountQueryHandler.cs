namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    public class GetCartsCountQueryHandler : IRequestHandler<GetCartsCountQuery, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsCountQueryHandler> _logger;

        public GetCartsCountQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<int> Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts.Where(x => x.User.Id == request.UserId).Count();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error getting the carts count.");
                return Task.FromResult(0);
            }
        }
    }
}

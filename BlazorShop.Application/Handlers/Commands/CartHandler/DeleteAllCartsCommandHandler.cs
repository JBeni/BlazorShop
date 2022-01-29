namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class DeleteAllCartsCommandHandler : IRequestHandler<DeleteAllCartsCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteAllCartsCommandHandler> _logger;

        public DeleteAllCartsCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Carts.RemoveRange(_dbContext.Carts.Where(x => x.User.Id == request.UserId));
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error deleting all the carts");
                return RequestResponse.Failure($"There was an error deleting all the carts. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

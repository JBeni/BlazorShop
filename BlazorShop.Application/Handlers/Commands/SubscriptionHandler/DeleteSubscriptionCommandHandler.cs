namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteSubscriptionCommandHandler> _logger;

        public DeleteSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteSubscriptionCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscriptions.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Subscriptions.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error deleting the subscription");
                return RequestResponse.Failure($"There was an error deleting the subscription. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

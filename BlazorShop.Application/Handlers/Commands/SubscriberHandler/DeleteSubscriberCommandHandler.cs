namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class DeleteSubscriberCommandHandler : IRequestHandler<DeleteSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteSubscriberCommandHandler> _logger;

        public DeleteSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteSubscriberCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscribers.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Subscribers.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error deleting the subscriber");
                return RequestResponse.Failure($"There was an error deleting the subscriber. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

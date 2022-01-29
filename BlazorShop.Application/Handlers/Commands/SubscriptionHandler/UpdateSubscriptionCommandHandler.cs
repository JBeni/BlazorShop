namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriptionCommandHandler> _logger;

        public UpdateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriptionCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscriptions.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.StripeSubscriptionId = request.StripeSubscriptionId;
                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Options = request.Options;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;

                _dbContext.Subscriptions.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the subscription");
                return RequestResponse.Failure("There was an error updating the subscription. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

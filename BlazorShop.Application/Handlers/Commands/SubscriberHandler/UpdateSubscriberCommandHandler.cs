namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class UpdateSubscriberCommandHandler : IRequestHandler<UpdateSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateSubscriberCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscribers.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                var subscription = _dbContext.Subscriptions.FirstOrDefault(x => x.Id == request.SubscriptionId);

                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.CurrentPeriodStart = DateTime.Now;
                entity.Subscription = subscription;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the subscriber", ex));
            }
        }
    }
}

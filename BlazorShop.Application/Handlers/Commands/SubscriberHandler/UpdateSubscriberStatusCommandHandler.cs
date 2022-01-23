namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class UpdateSubscriberStatusCommandHandler : IRequestHandler<UpdateSubscriberStatusCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateSubscriberStatusCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscribers.FirstOrDefault(x => x.StripeSubscriberSubscriptionId == request.StripeSubscriberSubscriptionId);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.Status = SubscriptionStatus.Inactive;

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

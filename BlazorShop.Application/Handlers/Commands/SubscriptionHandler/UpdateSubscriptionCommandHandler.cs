namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateSubscriptionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the subscription", ex));
            }
        }
    }
}

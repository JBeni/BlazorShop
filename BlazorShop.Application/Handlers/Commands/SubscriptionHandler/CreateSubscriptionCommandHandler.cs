namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateSubscriptionCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscriptions.FirstOrDefault(x => x.Id == request.Id);
                if (entity != null) throw new Exception("The entity already exists");

                entity = new Subscription
                {
                    StripeSubscriptionId = request.StripeSubscriptionId,
                    Name = request.Name,
                    Price = request.Price,
                    Currency = "usd",
                    CurrencySymbol = "$",
                    ChargeType = "month",
                    Options = request.Options,
                    ImagePath = request.ImagePath,
                    ImageName = request.ImageName,
                };

                _dbContext.Subscriptions.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the subscription", ex));
            }
        }
    }
}

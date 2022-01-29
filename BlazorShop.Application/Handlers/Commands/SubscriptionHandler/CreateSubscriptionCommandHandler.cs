namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateSubscriptionCommandHandler> _logger;

        public CreateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<CreateSubscriptionCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error creating the subscription");
                return RequestResponse.Failure("There was an error creating the subscription. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

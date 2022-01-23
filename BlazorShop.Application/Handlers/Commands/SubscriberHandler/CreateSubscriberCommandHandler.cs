namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class CreateSubscriberCommandHandler : IRequestHandler<CreateSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateSubscriberCommandHandler(IApplicationDbContext dbContext, IUserService userService, IMapper mapper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<RequestResponse> Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Subscriber entity = _dbContext.Subscribers.FirstOrDefault(x => x.Id == request.Id);
                if (entity != null) throw new Exception("The entity already exists");

                var customer = await _userService.FindUserByIdAsync(request.CustomerId);
                var subscription = _dbContext.Subscriptions.FirstOrDefault(x => x.Id == request.SubscriptionId);

                entity = new Subscriber
                {
                    Status = SubscriptionStatus.Inactive,
                    CurrentPeriodEnd = request.CurrentPeriodEnd,
                    CurrentPeriodStart = request.DateStart,
                    DateStart = request.DateStart,
                    Customer = customer,
                    Subscription = subscription,
                    StripeSubscriberSubscriptionId = "",
                    HostedInvoiceUrl = "",
                };

                _dbContext.Subscribers.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the subscriber", ex));
            }
        }
    }
}

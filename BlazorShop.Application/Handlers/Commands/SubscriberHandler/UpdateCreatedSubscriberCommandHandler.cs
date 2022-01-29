namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class UpdateCreatedSubscriberCommandHandler : IRequestHandler<UpdateCreatedSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateCreatedSubscriberCommandHandler> _logger;
        private readonly IUserService _userService;

        public UpdateCreatedSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateCreatedSubscriberCommandHandler> logger, IUserService userService)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.FindUserByEmailAsync(request.CustomerEmail);
                if (user == null) throw new Exception("The user does not exists");

                var entity = _dbContext.Subscribers.FirstOrDefault(x => x.Customer.Id == user.Id && x.StripeSubscriberSubscriptionId.Equals(""));
                if (entity == null) throw new Exception("The entity does not exists");

                entity.StripeSubscriberSubscriptionId = request.StripeSubscriberSubscriptionId;
                entity.HostedInvoiceUrl = request.HostedInvoiceUrl;
                entity.CurrentPeriodStart = request.CurrentPeriodStart;
                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.Status = SubscriptionStatus.Active;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the subscriber subscription after creation");
                return RequestResponse.Failure($"There was an error updating the subscriber subscription after creation. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

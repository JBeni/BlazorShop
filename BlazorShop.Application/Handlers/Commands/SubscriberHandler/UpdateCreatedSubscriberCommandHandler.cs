namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class UpdateCreatedSubscriberCommandHandler : IRequestHandler<UpdateCreatedSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserService _userService;

        public UpdateCreatedSubscriberCommandHandler(IApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<RequestResponse> Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userService.FindUserByEmailAsync(request.CustomerEmail);
                if (user == null) throw new Exception("The user does not exists");

                var entity = _dbContext.Subscribers.FirstOrDefault(x => x.Customer.Id == user.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.StripeSubscriberSubscriptionId = request.StripeSubscriberSubscriptionId;
                entity.HostedInvoiceUrl = request.HostedInvoiceUrl;
                entity.CurrentPeriodStart = request.CurrentPeriodStart;
                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.Status = request.Status;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the subscriber subscription after creation", ex));
            }
        }
    }
}

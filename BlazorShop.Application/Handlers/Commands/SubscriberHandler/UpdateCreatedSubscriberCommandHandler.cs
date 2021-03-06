// <copyright file="UpdateCreatedSubscriberCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task<RequestResponse> Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var user = await _userService.FindUserByEmailAsync(request.CustomerEmail);
                if (user == null) throw new Exception("The user does not exists");

                var entity = _dbContext.Subscribers
                    .TagWith(nameof(UpdateCreatedSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Customer.Id == user.Id && x.StripeSubscriberSubscriptionId.Equals(""));
                if (entity == null) throw new Exception("The subscriber does not exists");

                entity.StripeSubscriberSubscriptionId = request.StripeSubscriberSubscriptionId;
                entity.HostedInvoiceUrl = request.HostedInvoiceUrl;
                entity.CurrentPeriodStart = request.CurrentPeriodStart;
                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.Status = SubscriptionStatus.Active;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateCreatedSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateCreatedSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

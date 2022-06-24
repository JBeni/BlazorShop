// <copyright file="UpdateSubscriberCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateSubscriberCommandHandler : IRequestHandler<UpdateSubscriberCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriberCommandHandler> _logger;

        public UpdateSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriberCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(UpdateSubscriberCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscribers
                    .TagWith(nameof(UpdateSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The subscriber does not exists");

                var subscription = _dbContext.Subscriptions
                    .TagWith(nameof(UpdateSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.SubscriptionId);
                if (subscription == null) throw new Exception("The subscription does not exists");

                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.CurrentPeriodStart = DateTime.Now;
                entity.Subscription = subscription;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateSubscriberCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

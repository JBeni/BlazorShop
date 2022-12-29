// <copyright file="UpdateSubscriberCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateSubscriberCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateSubscriberCommandHandler : IRequestHandler<UpdateSubscriberCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateSubscriberCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateSubscriberCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateSubscriberCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriberCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

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
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

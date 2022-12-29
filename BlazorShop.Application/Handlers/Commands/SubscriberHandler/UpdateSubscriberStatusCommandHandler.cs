// <copyright file="UpdateSubscriberStatusCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateSubscriberStatusCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateSubscriberStatusCommandHandler : IRequestHandler<UpdateSubscriberStatusCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateSubscriberStatusCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateSubscriberStatusCommandHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateSubscriberStatusCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateSubscriberStatusCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriberStatusCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateSubscriberStatusCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Subscribers
                    .TagWith(nameof(UpdateSubscriberStatusCommandHandler))
                    .FirstOrDefault(x => x.StripeSubscriberSubscriptionId == request.StripeSubscriberSubscriptionId);
                if (entity == null) throw new Exception("The subscriber does not exists");

                entity.Status = SubscriptionStatus.Inactive;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateSubscriberStatusCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateSubscriberStatusCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

// <copyright file="UpdateSubscriberStatusCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="UpdateSubscriberStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateSubscriberStatusCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateSubscriberStatusCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriberStatusCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateSubscriberStatusCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateSubscriberStatusCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateSubscriberStatusCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Subscribers
                    .TagWith(nameof(UpdateSubscriberStatusCommandHandler))
                    .FirstOrDefault(x => x.StripeSubscriberSubscriptionId == request.StripeSubscriberSubscriptionId);
                if (entity == null)
                {
                    throw new Exception("The subscriber does not exists");
                }

                entity.Status = SubscriptionStatus.Inactive;

                this.DbContext.Subscribers.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateSubscriberStatusCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateSubscriberStatusCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

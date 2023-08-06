// <copyright file="UpdateSubscriptionCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateSubscriptionCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateSubscriptionCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriptionCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateSubscriptionCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateSubscriptionCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateSubscriptionCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Subscriptions
                    .TagWith(nameof(UpdateSubscriptionCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The subscription does not exists");
                }

                entity.StripeSubscriptionId = request.StripeSubscriptionId;
                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Options = request.Options;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;

                this.DbContext.Subscriptions.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateSubscriptionCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateSubscriptionCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

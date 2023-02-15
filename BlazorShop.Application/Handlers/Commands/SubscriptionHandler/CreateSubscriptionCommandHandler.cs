// <copyright file="CreateSubscriptionCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateSubscriptionCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateSubscriptionCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<CreateSubscriptionCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateSubscriptionCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateSubscriptionCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateSubscriptionCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Subscriptions
                    .TagWith(nameof(CreateSubscriptionCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity != null)
                {
                    throw new Exception("The subscription already exists");
                }

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

                this.DbContext.Subscriptions.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateSubscriptionCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateSubscriptionCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

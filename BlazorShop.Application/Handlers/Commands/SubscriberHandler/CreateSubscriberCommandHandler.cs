// <copyright file="CreateSubscriberCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateSubscriberCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateSubscriberCommandHandler : IRequestHandler<CreateSubscriberCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateSubscriberCommandHandler}"/>.</param>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<CreateSubscriberCommandHandler> logger, IUserService userService)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.UserService = userService;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateSubscriberCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateSubscriberCommandHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                Subscriber entity = this.DbContext.Subscribers
                    .TagWith(nameof(CreateSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity != null)
                {
                    throw new Exception("The subscriber already exists");
                }

                var customer = await this.UserService.FindUserByIdAsync(request.CustomerId);
                var subscription = this.DbContext.Subscriptions
                    .TagWith(nameof(CreateSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Id == request.SubscriptionId);

                entity = new Subscriber
                {
                    Status = SubscriptionStatus.Inactive,
                    CurrentPeriodEnd = request.CurrentPeriodEnd,
                    CurrentPeriodStart = request.DateStart,
                    DateStart = request.DateStart,
                    Customer = customer,
                    Subscription = subscription,
                    StripeSubscriberSubscriptionId = string.Empty,
                    HostedInvoiceUrl = string.Empty,
                };

                this.DbContext.Subscribers.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

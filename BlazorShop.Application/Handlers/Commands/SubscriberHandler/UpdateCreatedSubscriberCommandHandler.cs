// <copyright file="UpdateCreatedSubscriberCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateCreatedSubscriberCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateCreatedSubscriberCommandHandler : IRequestHandler<UpdateCreatedSubscriberCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCreatedSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateCreatedSubscriberCommandHandler}"/>.</param>
        /// <param name="userService">Gets An instance of <see cref="IUserService"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateCreatedSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateCreatedSubscriberCommandHandler> logger, IUserService userService)
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
        /// Gets An instance of <see cref="ILogger{UpdateCreatedSubscriberCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateCreatedSubscriberCommandHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IUserService"/>.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateCreatedSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateCreatedSubscriberCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var user = await this.UserService.FindUserByEmailAsync(request.CustomerEmail);
                if (user == null)
                {
                    throw new Exception("The user does not exists");
                }

                var entity = this.DbContext.Subscribers
                    .TagWith(nameof(UpdateCreatedSubscriberCommandHandler))
                    .FirstOrDefault(x => x.Customer.Id == user.Id && x.StripeSubscriberSubscriptionId.Equals(string.Empty));
                if (entity == null)
                {
                    throw new Exception("The subscriber does not exists");
                }

                entity.StripeSubscriberSubscriptionId = request.StripeSubscriberSubscriptionId;
                entity.HostedInvoiceUrl = request.HostedInvoiceUrl;
                entity.CurrentPeriodStart = request.CurrentPeriodStart;
                entity.CurrentPeriodEnd = request.CurrentPeriodEnd;
                entity.Status = SubscriptionStatus.Active;

                this.DbContext.Subscribers.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateCreatedSubscriberCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateCreatedSubscriberCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

// <copyright file="UpdateCreatedSubscriberCommandHandler.cs" author="Beniamin Jitca">
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
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{UpdateCreatedSubscriberCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<UpdateCreatedSubscriberCommandHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IUserService"/>.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCreatedSubscriberCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{UpdateCreatedSubscriberCommandHandler}"/>.</param>
        /// <param name="userService">An instance of <see cref="IUserService"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateCreatedSubscriberCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateCreatedSubscriberCommandHandler> logger, IUserService userService)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateCreatedSubscriberCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
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

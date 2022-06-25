// <copyright file="CreateSubscriptionCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateSubscriptionCommandHandler> _logger;

        public CreateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<CreateSubscriptionCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response =s></response =s>
        public async Task<RequestResponse> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Subscriptions
                    .TagWith(nameof(CreateSubscriptionCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity != null) throw new Exception("The subscription already exists");

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

                _dbContext.Subscriptions.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateSubscriptionCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateSubscriptionCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

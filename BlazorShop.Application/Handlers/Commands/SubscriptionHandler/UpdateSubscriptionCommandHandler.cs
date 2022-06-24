// <copyright file="UpdateSubscriptionCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriptionCommandHandler> _logger;

        public UpdateSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriptionCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscriptions
                    .TagWith(nameof(UpdateSubscriptionCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The subscription does not exists");

                entity.StripeSubscriptionId = request.StripeSubscriptionId;
                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Options = request.Options;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;

                _dbContext.Subscriptions.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateSubscriptionCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateSubscriptionCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

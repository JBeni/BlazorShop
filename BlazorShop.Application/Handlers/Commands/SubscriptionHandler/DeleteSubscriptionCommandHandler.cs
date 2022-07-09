// <copyright file="DeleteSubscriptionCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriptionHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteSubscriptionCommandHandler> _logger;

        public DeleteSubscriptionCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteSubscriptionCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Subscriptions
                    .TagWith(nameof(DeleteSubscriptionCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The subscription does not exists");

                _dbContext.Subscriptions.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteSubscriptionCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteSubscriptionCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

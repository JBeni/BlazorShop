// <copyright file="UpdateOrderCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateOrderCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Orders
                    .TagWith(nameof(UpdateOrderCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The order does not exists");

                entity.UserEmail = request.UserEmail;
                entity.OrderDate = request.OrderDate;
                entity.LineItems = request.LineItems;
                entity.AmountTotal = request.AmountTotal;

                _dbContext.Orders.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateOrderCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateOrderCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

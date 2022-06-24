// <copyright file="DeleteReceiptCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteReceiptCommandHandler : IRequestHandler<DeleteReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteReceiptCommandHandler> _logger;

        public DeleteReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteReceiptCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Receipts
                    .TagWith(nameof(DeleteReceiptCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The receipt does not exists");

                _dbContext.Receipts.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteReceiptCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

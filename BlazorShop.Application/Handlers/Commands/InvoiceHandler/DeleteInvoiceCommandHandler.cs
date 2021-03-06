// <copyright file="DeleteInvoiceCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteInvoiceCommandHandler> _logger;

        public DeleteInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteInvoiceCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Invoices
                    .TagWith(nameof(DeleteInvoiceCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The invoice does not exists");

                _dbContext.Invoices.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteInvoiceCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

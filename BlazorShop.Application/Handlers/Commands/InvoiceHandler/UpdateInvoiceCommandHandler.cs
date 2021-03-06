// <copyright file="UpdateInvoiceCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateInvoiceCommandHandler> _logger;

        public UpdateInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateInvoiceCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Invoices
                    .TagWith(nameof(UpdateInvoiceCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The invoice does not exists");

                entity.UserEmail = request.UserEmail;
                entity.Name = request.Name;
                entity.AmountSubTotal = request.AmountSubTotal;
                entity.AmountTotal = request.AmountTotal;
                entity.Quantity = request.Quantity;

                _dbContext.Invoices.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateInvoiceCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

// <copyright file="CreateInvoiceCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateInvoiceCommandHandler> _logger;

        public CreateInvoiceCommandHandler(IApplicationDbContext dbContext, ILogger<CreateInvoiceCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Invoice
                {
                    UserEmail = request.UserEmail,
                    Name = request.Name,
                    AmountSubTotal = request.AmountSubTotal,
                    AmountTotal = request.AmountTotal,
                    Quantity = request.Quantity,
                };

                _dbContext.Invoices.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateInvoiceCommand);
                return RequestResponse.Failure($"{ErrorsManager.CreateInvoiceCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

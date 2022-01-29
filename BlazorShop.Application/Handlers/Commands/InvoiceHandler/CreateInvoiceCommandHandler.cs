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
                _logger.LogError(ex, "There was an error creating the invoice");
                return RequestResponse.Failure("There was an error creating the invoice. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

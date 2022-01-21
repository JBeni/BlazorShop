namespace BlazorShop.Application.Handlers.Commands.InvoiceCommand
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateInvoiceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the invoice", ex));
            }
        }
    }
}

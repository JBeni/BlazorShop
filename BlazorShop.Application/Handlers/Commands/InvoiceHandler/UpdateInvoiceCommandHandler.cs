namespace BlazorShop.Application.Handlers.Commands.InvoiceHandler
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateInvoiceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Invoices.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.UserEmail = request.UserEmail;
                entity.Name = request.Name;
                entity.AmountSubTotal = request.AmountSubTotal;
                entity.AmountTotal = request.AmountTotal;
                entity.Quantity = request.Quantity;

                _dbContext.Invoices.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the invoice", ex));
            }
        }
    }
}

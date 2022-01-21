namespace BlazorShop.Application.Handlers.Commands.InvoiceCommand
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteInvoiceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Invoices.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Invoices.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the invoice", ex));
            }
        }
    }
}

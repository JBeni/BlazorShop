namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    public class DeleteReceiptCommandHandler : IRequestHandler<DeleteReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteReceiptCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Receipts.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Receipts.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the receipt", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.ReceiptCommand
{
    public class UpdateReceiptCommandHandler : IRequestHandler<UpdateReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateReceiptCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Receipts.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.ReceiptDate = request.ReceiptDate;
                entity.ReceiptName = request.ReceiptName;
                entity.ReceiptUrl = request.ReceiptUrl;

                _dbContext.Receipts.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the receipt", ex));
            }
        }
    }
}

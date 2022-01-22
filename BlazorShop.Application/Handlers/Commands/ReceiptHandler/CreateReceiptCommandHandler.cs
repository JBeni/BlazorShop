namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateReceiptCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Receipt
                {
                    ReceiptDate = request.ReceiptDate,
                    ReceiptName = request.ReceiptName,
                    ReceiptUrl = request.ReceiptUrl,
                };

                _dbContext.Receipts.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the receipt", ex));
            }
        }
    }
}

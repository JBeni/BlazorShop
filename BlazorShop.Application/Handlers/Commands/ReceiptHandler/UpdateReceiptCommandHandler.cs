namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    public class UpdateReceiptCommandHandler : IRequestHandler<UpdateReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateReceiptCommandHandler> _logger;

        public UpdateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateReceiptCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the receipt");
                return RequestResponse.Failure($"There was an error updating the receipt. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

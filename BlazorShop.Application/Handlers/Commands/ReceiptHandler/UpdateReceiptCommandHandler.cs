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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(UpdateReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Receipts.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The receipt does not exists");

                entity.ReceiptDate = request.ReceiptDate;
                entity.ReceiptName = request.ReceiptName;
                entity.ReceiptUrl = request.ReceiptUrl;

                _dbContext.Receipts.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateReceiptCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateReceiptCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

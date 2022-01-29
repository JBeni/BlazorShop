namespace BlazorShop.Application.Handlers.Commands.ReceiptHandler
{
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateReceiptCommandHandler> _logger;

        public CreateReceiptCommandHandler(IApplicationDbContext dbContext, ILogger<CreateReceiptCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Receipt
                {
                    UserEmail = request.UserEmail,
                    ReceiptDate = request.ReceiptDate,
                    ReceiptName = request.ReceiptName,
                    ReceiptUrl = request.ReceiptUrl,
                };

                _dbContext.Receipts.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error creating the receipt");
                return RequestResponse.Failure("There was an error creating the receipt. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

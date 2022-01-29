namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, Result<ReceiptResponse>>
    {
        private readonly IApplicationDbContext _dbContext; 
        private readonly ILogger<GetReceiptByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetReceiptByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<ReceiptResponse>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Receipts
                    .Where(x => x.Id == request.Id && x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<ReceiptResponse>
                {
                    Successful = true,
                    Item = result ?? new ReceiptResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the receipt by id");
                return Task.FromResult(new Result<ReceiptResponse>
                {
                    Error = $"There was an error while getting the receipt by id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

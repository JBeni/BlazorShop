namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, List<ReceiptResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetReceiptsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetReceiptsQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<List<ReceiptResponse>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Receipts
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the receipt by id...");
                return Task.FromResult(new List<ReceiptResponse>
                {
                    new ReceiptResponse
                    {
                        Error = "There was an error while getting the receipt by id... " + ex.Message ?? ex.InnerException.Message
                    }
                });
            }
        }
    }
}

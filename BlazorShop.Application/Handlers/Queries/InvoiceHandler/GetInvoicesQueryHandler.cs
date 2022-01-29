namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, Result<InvoiceResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetInvoicesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInvoicesQueryHandler(IApplicationDbContext dbContext, ILogger<GetInvoicesQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<Result<InvoiceResponse>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Invoices
                    .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Successful = true,
                    Items = result ?? new List<InvoiceResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the invoices");
                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Error = $"There was an error while getting the invoices. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

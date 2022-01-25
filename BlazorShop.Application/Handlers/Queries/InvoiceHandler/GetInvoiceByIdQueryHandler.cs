namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetInvoiceByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetInvoiceByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public Task<InvoiceResponse> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Invoices
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the invoice by id...");
                return Task.FromResult(new InvoiceResponse
                {
                    Error = "There was an error while getting the invoice by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

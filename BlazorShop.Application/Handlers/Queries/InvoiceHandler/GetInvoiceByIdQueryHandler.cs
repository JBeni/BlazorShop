namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Result<InvoiceResponse>>
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

        public Task<Result<InvoiceResponse>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Invoices
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Successful = true,
                    Item = result ?? new InvoiceResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetInvoiceByIdQuery);
                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Error = $"{ErrorsManager.GetInvoiceByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

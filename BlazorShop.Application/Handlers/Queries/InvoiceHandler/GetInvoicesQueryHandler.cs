// <copyright file="GetInvoicesQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<InvoiceResponse>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            Result<InvoiceResponse>? response;

            try
            {
                var result = _dbContext.Invoices
                    .TagWith(nameof(GetInvoicesQueryHandler))
                    .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<InvoiceResponse>
                {
                    Successful = true,
                    Items = result ?? new List<InvoiceResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetInvoicesQuery);
                response = new Result<InvoiceResponse>
                {
                    Error = $"{ErrorsManager.GetInvoicesQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

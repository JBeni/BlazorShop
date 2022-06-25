// <copyright file="GetInvoiceByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<InvoiceResponse>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            Result<InvoiceResponse>? response;

            try
            {
                var result = _dbContext.Invoices
                    .TagWith(nameof(GetInvoiceByIdQueryHandler))
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<InvoiceResponse>
                {
                    Successful = true,
                    Item = result ?? new InvoiceResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetInvoiceByIdQuery);
                response = new Result<InvoiceResponse>
                {
                    Error = $"{ErrorsManager.GetInvoiceByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

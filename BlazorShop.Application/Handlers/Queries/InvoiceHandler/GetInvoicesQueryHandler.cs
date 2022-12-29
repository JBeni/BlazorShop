// <copyright file="GetInvoicesQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetInvoicesQuery, Result{InvoiceResponse}}"/>.
    /// </summary>
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, Result<InvoiceResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetInvoicesQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetInvoicesQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoicesQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetInvoicesQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetInvoicesQueryHandler(IApplicationDbContext dbContext, ILogger<GetInvoicesQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetInvoicesQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{InvoiceResponse}}"/>.</returns>
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

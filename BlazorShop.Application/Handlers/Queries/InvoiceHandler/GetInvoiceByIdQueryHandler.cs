// <copyright file="GetInvoiceByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.InvoiceHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetInvoiceByIdQuery, InvoiceResponse}"/>.
    /// </summary>
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Result<InvoiceResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetInvoiceByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetInvoiceByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetInvoiceByIdQueryHandler> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetInvoiceByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetInvoiceByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetInvoiceByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{InvoiceResponse}"/>.</returns>
        public Task<Result<InvoiceResponse>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            Result<InvoiceResponse>? response;

            try
            {
                var result = this.DbContext.Invoices
                    .TagWith(nameof(GetInvoiceByIdQueryHandler))
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<InvoiceResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<InvoiceResponse>
                {
                    Successful = true,
                    Item = result ?? new InvoiceResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetInvoiceByIdQuery);
                response = new Result<InvoiceResponse>
                {
                    Error = $"{ErrorsManager.GetInvoiceByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

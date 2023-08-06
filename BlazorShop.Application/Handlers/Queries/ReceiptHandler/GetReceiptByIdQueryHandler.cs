// <copyright file="GetReceiptByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetReceiptByIdQuery, ReceiptResponse}"/>.
    /// </summary>
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, Result<ReceiptResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetReceiptByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetReceiptByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetReceiptByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetReceiptByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetReceiptByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{ReceiptResponse}"/>.</returns>
        public Task<Result<ReceiptResponse>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            Result<ReceiptResponse>? response;

            try
            {
                var result = this.DbContext.Receipts
                    .TagWith(nameof(GetReceiptByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<ReceiptResponse>
                {
                    Successful = true,
                    Item = result ?? new ReceiptResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetReceiptByIdQuery);
                response = new Result<ReceiptResponse>
                {
                    Error = $"{ErrorsManager.GetReceiptByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

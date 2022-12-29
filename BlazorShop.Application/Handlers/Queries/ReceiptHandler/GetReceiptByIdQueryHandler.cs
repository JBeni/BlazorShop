// <copyright file="GetReceiptByIdQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetReceiptByIdQuery, Result{ReceiptResponse}}"/>.
    /// </summary>
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, Result<ReceiptResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetReceiptByIdQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetReceiptByIdQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetReceiptByIdQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetReceiptByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetReceiptByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{ReceiptResponse}}"/>.</returns>
        public Task<Result<ReceiptResponse>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            Result<ReceiptResponse>? response;

            try
            {
                var result = _dbContext.Receipts
                    .TagWith(nameof(GetReceiptByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<ReceiptResponse>
                {
                    Successful = true,
                    Item = result ?? new ReceiptResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetReceiptByIdQuery);
                response = new Result<ReceiptResponse>
                {
                    Error = $"{ErrorsManager.GetReceiptByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

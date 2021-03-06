// <copyright file="GetReceiptByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, Result<ReceiptResponse>>
    {
        private readonly IApplicationDbContext _dbContext; 
        private readonly ILogger<GetReceiptByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetReceiptByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptByIdQueryHandler> logger, IMapper mapper)
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

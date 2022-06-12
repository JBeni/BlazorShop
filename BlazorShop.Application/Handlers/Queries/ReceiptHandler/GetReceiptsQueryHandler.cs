﻿namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    public class GetReceiptsQueryHandler : IRequestHandler<GetReceiptsQuery, Result<ReceiptResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetReceiptsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetReceiptsQueryHandler(IApplicationDbContext dbContext, ILogger<GetReceiptsQueryHandler> logger, IMapper mapper)
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
        public Task<Result<ReceiptResponse>> Handle(GetReceiptsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Receipts
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<ReceiptResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<ReceiptResponse>
                {
                    Successful = true,
                    Items = result ?? new List<ReceiptResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetReceiptsQuery);
                return Task.FromResult(new Result<ReceiptResponse>
                {
                    Error = $"{ErrorsManager.GetReceiptsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

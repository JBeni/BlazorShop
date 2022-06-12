namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IApplicationDbContext dbContext, ILogger<CreateOrderCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Order
                {
                    UserEmail = request.UserEmail,
                    OrderName = "Order reference " + Guid.NewGuid(),
                    OrderDate = request.OrderDate,
                    LineItems = request.LineItems,
                    AmountTotal = request.AmountTotal,
                };

                _dbContext.Orders.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateOrderCommand);
                return RequestResponse.Failure($"{ErrorsManager.CreateOrderCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

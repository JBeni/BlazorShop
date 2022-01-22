namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateOrderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Order
                {
                    UserEmail = request.UserEmail,
                    OrderDate = request.OrderDate,
                    LineItems = request.LineItems,
                    AmountTotal = request.AmountTotal,
                };

                _dbContext.Orders.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the order", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.OrderCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateOrderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Orders.SingleOrDefault(d => d.Id == request.Id);
                entity.Quantity = request.Quantity;

                _dbContext.Orders.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the order", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteOrderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Orders.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Orders.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the order", ex));
            }
        }
    }
}

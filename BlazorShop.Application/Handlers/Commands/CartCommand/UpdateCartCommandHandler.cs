namespace BlazorShop.Application.Handlers.Commands.CartCommand
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCartCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Carts.FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);

                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Amount = request.Amount;

                _dbContext.Carts.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the cart", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCartCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Carts.FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);

                _dbContext.Carts.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the cart", ex));
            }
        }
    }
}

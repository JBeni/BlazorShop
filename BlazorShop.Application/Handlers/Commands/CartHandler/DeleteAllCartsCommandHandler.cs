namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class DeleteAllCartsCommandHandler : IRequestHandler<DeleteAllCartsCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteAllCartsCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Carts.RemoveRange(_dbContext.Carts.Where(x => x.User.Id == request.UserId));
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting all the carts", ex));
            }
        }
    }
}

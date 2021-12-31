namespace BlazorShop.Application.Handlers.Commands.ProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Products.SingleOrDefault(d => d.Id == request.Id);

                _dbContext.Products.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the product", ex));
            }
        }
    }
}

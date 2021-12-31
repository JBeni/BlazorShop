namespace BlazorShop.Application.Handlers.Commands.ProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Products.SingleOrDefault(d => d.Id == request.Id);
                entity.Description = request.Description;
                entity.Price = request.Price;

                _dbContext.Products.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the product", ex));
            }
        }
    }
}

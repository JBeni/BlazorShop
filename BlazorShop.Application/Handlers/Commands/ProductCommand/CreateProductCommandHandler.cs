namespace BlazorShop.Application.Handlers.Commands.ProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProductCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                };

                _dbContext.Products.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the product", ex));
            }
        }
    }
}

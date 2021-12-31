namespace BlazorShop.Application.Handlers.Commands.ProductPhotoCommand
{
    public class CreateProductPhotoCommandHandler : IRequestHandler<CreateProductPhotoCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProductPhotoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateProductPhotoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new ProductPhoto
                {
                    RelativePathImage = request.Image
                };

                _dbContext.ProductPhotos.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the product photo", ex));
            }
        }
    }
}

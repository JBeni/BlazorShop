namespace BlazorShop.Application.Handlers.Commands.ProductPhotoCommand
{
    public class UpdateProductPhotoCommandHandler : IRequestHandler<UpdateProductPhotoCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateProductPhotoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.ProductPhotos.SingleOrDefault(d => d.Id == request.Id);
                entity.RelativePathImage = request.Image;

                _dbContext.ProductPhotos.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the product photo", ex));
            }
        }
    }
}

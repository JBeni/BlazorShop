namespace BlazorShop.Application.Handlers.Commands.ProductPhotoCommand
{
    public class DeleteProductPhotoCommandHandler : IRequestHandler<DeleteProductPhotoCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteProductPhotoCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteProductPhotoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.ProductPhotos.SingleOrDefault(d => d.Id == request.Id);

                _dbContext.ProductPhotos.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the product photo", ex));
            }
        }
    }
}

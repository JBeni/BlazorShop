namespace BlazorShop.Application.Handlers.Commands.CategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Categories.SingleOrDefault(d => d.Id == request.Id);

                _dbContext.Categories.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the category", ex));
            }
        }
    }
}

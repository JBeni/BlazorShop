namespace BlazorShop.Application.Handlers.Commands.CategoryCommand
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Categories.SingleOrDefault(p => p.Id == request.Id);
                entity.Name = request.Name;

                _dbContext.Categories.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the category", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.CategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Category
                {
                    Name = request.Name
                };

                _dbContext.Categories.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the category", ex));
            }
        }
    }
}

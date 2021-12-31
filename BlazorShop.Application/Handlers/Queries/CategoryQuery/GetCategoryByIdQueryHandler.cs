namespace BlazorShop.Application.Handlers.Queries.CategoryQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Categories
                    .Where(v => v.Id == request.Id)
                    .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CategoryResponse
                {
                    Error = "There was an error getting the category... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

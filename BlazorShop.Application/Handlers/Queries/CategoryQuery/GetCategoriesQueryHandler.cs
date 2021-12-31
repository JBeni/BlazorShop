namespace BlazorShop.Application.Handlers.Queries.CategoryQuery
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Categories
                    .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                List<CategoryResponse> projectsView = new();
                projectsView.Add(new CategoryResponse
                {
                    Error = "There was an error getting the categories... " + ex.Message ?? ex.InnerException.Message
                });
                return Task.FromResult(projectsView);
            }
        }
    }
}

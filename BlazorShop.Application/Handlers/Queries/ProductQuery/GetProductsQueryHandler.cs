namespace BlazorShop.Application.Handlers.Queries.ProductQuery
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Products
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                List<ProductResponse> productsView = new();
                productsView.Add(new ProductResponse
                {
                    Error = "There was an error while getting the products... " + ex.Message ?? ex.InnerException.Message
                });
                return Task.FromResult(productsView);
            }
        }
    }
}

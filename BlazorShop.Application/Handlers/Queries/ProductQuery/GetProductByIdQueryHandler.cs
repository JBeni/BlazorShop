namespace BlazorShop.Application.Handlers.Queries.ProductQuery
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Products
                    .Where(d => d.Id == request.Id)
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ProductResponse
                {
                    Error = "There was an error while getting the product... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Queries.ProductPhotoQuery
{
    public class GetProductPhotoByIdQueryHandler : IRequestHandler<GetProductPhotoByIdQuery, ProductPhotoResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductPhotoByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ProductPhotoResponse> Handle(GetProductPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.ProductPhotos
                    .Where(d => d.Id == request.Id)
                    .ProjectTo<ProductPhotoResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ProductPhotoResponse
                {
                    Error = "There was an error while getting the product photo... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

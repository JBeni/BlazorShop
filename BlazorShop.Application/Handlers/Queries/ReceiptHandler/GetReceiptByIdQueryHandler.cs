namespace BlazorShop.Application.Handlers.Queries.ReceiptHandler
{
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, ReceiptResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReceiptByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ReceiptResponse> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Receipts
                    .Where(x => x.Id == request.Id)
                    .ProjectTo<ReceiptResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ReceiptResponse
                {
                    Error = "There was an error while getting the receipt by id... " + ex.Message ?? ex.InnerException.Message
                });
            }
        }
    }
}

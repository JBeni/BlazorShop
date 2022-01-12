namespace BlazorShop.Application.Handlers.Queries.CartQuery
{
    public class GetCartsCountQueryHandler : IRequestHandler<GetCartsCountQuery, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetCartsCountQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts.Where(x => x.User.Id == request.UserId).Count();
                return Task.FromResult(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

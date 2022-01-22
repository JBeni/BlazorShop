namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public CreateCartCommandHandler(IApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<RequestResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clothe = _dbContext.Clothes.FirstOrDefault(x => x.Id == request.ClotheId);
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());

                var entity = new Cart
                {
                    Name = request.Name,
                    Price = request.Price,
                    Amount = request.Amount,
                    Clothe = clothe,
                    User = user
                };

                _dbContext.Carts.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the cart", ex));
            }
        }
    }
}

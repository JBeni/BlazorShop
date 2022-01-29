namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateCartCommandHandler> _logger;
        private readonly UserManager<User> _userManager;

        public CreateCartCommandHandler(IApplicationDbContext dbContext, ILogger<CreateCartCommandHandler> logger, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error creating the cart");
                return RequestResponse.Failure("There was an error creating the cart. " + ex.Message ?? ex.InnerException.Message);
            }
        }
    }
}

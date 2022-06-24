// <copyright file="CreateCartCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clothe = _dbContext.Clothes
                    .TagWith(nameof(CreateCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.ClotheId);
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null) throw new Exception("The user does not exists");

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
                _logger.LogError(ex, ErrorsManager.CreateCartCommand);
                return RequestResponse.Failure($"{ErrorsManager.CreateCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

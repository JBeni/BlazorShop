// <copyright file="CreateCartCommandHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateCartCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, RequestResponse>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{CreateCartCommandHandler}"/>.
        /// </summary>
        private readonly ILogger<CreateCartCommandHandler> _logger;

        /// <summary>
        /// An instance of <see cref="UserManager{User}"/>.
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="userManager">An instance of <see cref="UserManager{User}"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{CreateCartCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateCartCommandHandler(IApplicationDbContext dbContext, ILogger<CreateCartCommandHandler> logger, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateCartCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

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
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateCartCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

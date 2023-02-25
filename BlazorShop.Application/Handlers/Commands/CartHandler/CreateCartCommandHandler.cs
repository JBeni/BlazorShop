// <copyright file="CreateCartCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
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
        /// Initializes a new instance of the <see cref="CreateCartCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="userManager">Gets An instance of <see cref="UserManager{User}"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateCartCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateCartCommandHandler(IApplicationDbContext dbContext, ILogger<CreateCartCommandHandler> logger, UserManager<User> userManager)
        {
            this.DbContext = dbContext;
            this.UserManager = userManager;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateCartCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateCartCommandHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="UserManager{User}"/>.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateCartCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var clothe = this.DbContext.Clothes
                    .TagWith(nameof(CreateCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.ClotheId);
                var user = await this.UserManager.FindByIdAsync(request.UserId.ToString())
                    ?? throw new Exception("The user does not exists");
                var entity = new Cart
                {
                    Name = request.Name,
                    Price = request.Price,
                    Amount = request.Amount,
                    Clothe = clothe,
                    User = user,
                };

                this.DbContext.Carts.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateCartCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

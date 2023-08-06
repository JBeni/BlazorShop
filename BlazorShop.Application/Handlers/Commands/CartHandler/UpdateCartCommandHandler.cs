// <copyright file="UpdateCartCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateCartCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCartCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateCartCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateCartCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateCartCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateCartCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateCartCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateCartCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Carts
                    .TagWith(nameof(UpdateCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);
                if (entity == null)
                {
                    throw new Exception("The cart do not exists");
                }

                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Amount = request.Amount;

                this.DbContext.Carts.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateCartCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

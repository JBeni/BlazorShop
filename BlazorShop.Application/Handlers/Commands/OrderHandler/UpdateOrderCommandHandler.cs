// <copyright file="UpdateOrderCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateOrderCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateOrderCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateOrderCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateOrderCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateOrderCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateOrderCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateOrderCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/>.</returns>
        public async Task<RequestResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Orders
                    .TagWith(nameof(UpdateOrderCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The order does not exists");
                }

                entity.UserEmail = request.UserEmail;
                entity.OrderDate = request.OrderDate;
                entity.LineItems = request.LineItems;
                entity.AmountTotal = request.AmountTotal;

                this.DbContext.Orders.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateOrderCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateOrderCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

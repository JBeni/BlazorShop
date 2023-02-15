﻿// <copyright file="DeleteOrderCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteOrderCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteOrderCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteOrderCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteOrderCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteOrderCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteOrderCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteOrderCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Orders
                    .TagWith(nameof(DeleteOrderCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The order does not exists");
                }

                this.DbContext.Orders.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteOrderCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteOrderCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

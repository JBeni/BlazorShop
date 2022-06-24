// <copyright file="DeleteAllCartsCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteAllCartsCommandHandler : IRequestHandler<DeleteAllCartsCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteAllCartsCommandHandler> _logger;

        public DeleteAllCartsCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteAllCartsCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(DeleteAllCartsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.Carts.RemoveRange(
                    _dbContext.Carts
                        .TagWith(nameof(DeleteAllCartsCommandHandler))
                        .Where(x => x.User.Id == request.UserId)
                );
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteAllCartsCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteAllCartsCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

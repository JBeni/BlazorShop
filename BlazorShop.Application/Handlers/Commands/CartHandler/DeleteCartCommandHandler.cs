// <copyright file="DeleteCartCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteCartCommandHandler> _logger;

        public DeleteCartCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteCartCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Carts
                    .TagWith(nameof(DeleteCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);
                if (entity == null) throw new Exception("The cart does not exists");

                _dbContext.Carts.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteCartCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

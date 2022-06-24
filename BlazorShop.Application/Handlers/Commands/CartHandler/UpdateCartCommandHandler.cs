// <copyright file="UpdateCartCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.CartHandler
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateCartCommandHandler> _logger;

        public UpdateCartCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateCartCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Carts
                    .TagWith(nameof(UpdateCartCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id && x.User.Id == request.UserId);
                if (entity == null) throw new Exception("The cart do not exists");

                entity.Name = request.Name;
                entity.Price = request.Price;
                entity.Amount = request.Amount;

                _dbContext.Carts.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateCartCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateCartCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

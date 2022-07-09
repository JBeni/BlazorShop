// <copyright file="GetCartsCountQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartsCountQueryHandler : IRequestHandler<GetCartsCountQuery, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsCountQueryHandler> _logger;

        public GetCartsCountQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandler> logger)
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
        public Task<int> Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
            var result = 0;

            try
            {
                result = _dbContext.Carts
                    .TagWith(nameof(GetCartsCountQueryHandler))
                    .Where(x => x.User.Id == request.UserId).Count();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetCartsCountQuery);
            }

            return Task.FromResult(result);
        }
    }
}

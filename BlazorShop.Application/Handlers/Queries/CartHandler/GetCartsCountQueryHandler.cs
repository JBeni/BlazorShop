// <copyright file="GetCartsCountQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetCartsCountQuery}"/>.
    /// </summary>
    public class GetCartsCountQueryHandler : IRequestHandler<GetCartsCountQuery, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsCountQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetCartsCountQueryHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetCartsCountQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetCartsCountQueryHandler}"/>.
        /// </summary>
        private ILogger<GetCartsCountQueryHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetCartsCountQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="int"/>.</returns>
        public Task<int> Handle(GetCartsCountQuery request, CancellationToken cancellationToken)
        {
            var result = 0;

            try
            {
                result = this.DbContext.Carts
                    .TagWith(nameof(GetCartsCountQueryHandler))
                    .Where(x => x.User.Id == request.UserId).Count();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetCartsCountQuery);
            }

            return Task.FromResult(result);
        }
    }
}

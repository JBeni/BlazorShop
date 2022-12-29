// <copyright file="GetCartsCountQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetCartsCountQuery, int}"/>.
    /// </summary>
    public class GetCartsCountQueryHandler : IRequestHandler<GetCartsCountQuery, int>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetCartsCountQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetCartsCountQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsCountQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetCartsCountQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetCartsCountQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsCountQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetCartsCountQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{int}"/>.</returns>
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

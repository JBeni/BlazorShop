// <copyright file="GetCartsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetCartsQuery, CartResponse}"/>.
    /// </summary>
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, Result<CartResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetCartsQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetCartsQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsQueryHandler> logger, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{GetCartsQueryHandler}"/>.
        /// </summary>
        private ILogger<GetCartsQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetCartsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{CartResponse}"/>.</returns>
        public Task<Result<CartResponse>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            Result<CartResponse>? response;

            try
            {
                var result = this.DbContext.Carts
                    .TagWith(nameof(GetCartsQueryHandler))
                    .Where(x => x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<CartResponse>
                {
                    Successful = true,
                    Items = result ?? new List<CartResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetCartsQuery);
                response = new Result<CartResponse>
                {
                    Error = $"{ErrorsManager.GetCartsQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

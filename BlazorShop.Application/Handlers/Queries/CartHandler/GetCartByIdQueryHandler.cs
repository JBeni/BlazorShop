// <copyright file="GetCartByIdQueryHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetCartByIdQuery, CartResponse}"/>.
    /// </summary>
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Result<CartResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetCartByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetCartByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetCartByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetCartByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetCartByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{CartResponse}"/>.</returns>
        public Task<Result<CartResponse>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            Result<CartResponse>? response;

            try
            {
                var result = this.DbContext.Carts
                    .TagWith(nameof(GetCartByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<CartResponse>
                {
                    Successful = true,
                    Item = result ?? new CartResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetCartByIdQuery);
                response = new Result<CartResponse>
                {
                    Error = $"{ErrorsManager.GetCartByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

// <copyright file="GetOrderByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetOrderByIdQuery, OrderResponse}"/>.
    /// </summary>
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetOrderByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetOrderByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrderByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetOrderByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetOrderByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetOrderByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{OrderResponse}"/>.</returns>
        public Task<Result<OrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Result<OrderResponse>? response;

            try
            {
                var result = this.DbContext.Orders
                    .TagWith(nameof(GetOrderByIdQueryHandler))
                    .Where(d => d.Id == request.Id && d.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<OrderResponse>
                {
                    Successful = true,
                    Item = result ?? new OrderResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetOrderByIdQuery);
                response = new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrderByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

// <copyright file="GetOrdersQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.OrderHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetOrdersQuery, OrderResponse}"/>.
    /// </summary>
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<OrderResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrdersQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetOrdersQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetOrdersQueryHandler(IApplicationDbContext dbContext, ILogger<GetOrdersQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetOrdersQueryHandler}"/>.
        /// </summary>
        private ILogger<GetOrdersQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetOrdersQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{OrderResponse}"/>.</returns>
        public Task<Result<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Result<OrderResponse>? response;

            try
            {
                var result = this.DbContext.Orders
                    .TagWith(nameof(GetOrdersQueryHandler))
                    .Where(x => x.UserEmail == request.UserEmail)
                    .ProjectTo<OrderResponse>(this.Mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<OrderResponse>
                {
                    Successful = true,
                    Items = result ?? new List<OrderResponse>(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetOrdersQuery);
                response = new Result<OrderResponse>
                {
                    Error = $"{ErrorsManager.GetOrdersQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

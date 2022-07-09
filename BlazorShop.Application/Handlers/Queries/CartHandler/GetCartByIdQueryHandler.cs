// <copyright file="GetCartByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Result<CartResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCartByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartByIdQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<CartResponse>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            Result<CartResponse>? response;

            try
            {
                var result = _dbContext.Carts
                    .TagWith(nameof(GetCartByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<CartResponse>
                {
                    Successful = true,
                    Item = result ?? new CartResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetCartByIdQuery);
                response = new Result<CartResponse>
                {
                    Error = $"{ErrorsManager.GetCartByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

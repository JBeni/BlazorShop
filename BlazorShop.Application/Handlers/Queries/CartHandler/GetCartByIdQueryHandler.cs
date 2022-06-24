// <copyright file="GetCartByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
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
            try
            {
                var result = _dbContext.Carts
                    .TagWith(nameof(GetCartByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                return Task.FromResult(new Result<CartResponse>
                {
                    Successful = true,
                    Item = result ?? new CartResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetCartByIdQuery);
                return Task.FromResult(new Result<CartResponse>
                {
                    Error = $"{ErrorsManager.GetCartByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

// <copyright file="GetCartsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.CartHandler
{
    public class GetCartsQueryHandler : IRequestHandler<GetCartsQuery, Result<CartResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetCartsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetCartsQueryHandler(IApplicationDbContext dbContext, ILogger<GetCartsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<CartResponse>> Handle(GetCartsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Carts
                    .TagWith(nameof(GetCartsQueryHandler))
                    .Where(x => x.User.Id == request.UserId)
                    .ProjectTo<CartResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<CartResponse>
                {
                    Successful = true,
                    Items = result ?? new List<CartResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetCartsQuery);
                return Task.FromResult(new Result<CartResponse>
                {
                    Error = $"{ErrorsManager.GetCartsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}

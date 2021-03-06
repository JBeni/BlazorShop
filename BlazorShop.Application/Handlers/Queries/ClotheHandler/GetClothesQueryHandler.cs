// <copyright file="GetClothesQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, Result<ClotheResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetClothesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetClothesQueryHandler(IApplicationDbContext dbContext, ILogger<GetClothesQueryHandler> logger, IMapper mapper)
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
        public Task<Result<ClotheResponse>> Handle(GetClothesQuery request, CancellationToken cancellationToken)
        {
            Result<ClotheResponse>? response;

            try
            {
                var result = _dbContext.Clothes
                    .TagWith(nameof(GetClothesQueryHandler))
                    .Where(x => x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<ClotheResponse>
                {
                    Successful = true,
                    Items = result ?? new List<ClotheResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetClothesQuery);
                response = new Result<ClotheResponse>
                {
                    Error = $"{ErrorsManager.GetClothesQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

// <copyright file="GetClotheByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetClotheByIdQueryHandler : IRequestHandler<GetClotheByIdQuery, Result<ClotheResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetClotheByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetClotheByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetClotheByIdQueryHandler> logger, IMapper mapper)
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
        public Task<Result<ClotheResponse>> Handle(GetClotheByIdQuery request, CancellationToken cancellationToken)
        {
            Result<ClotheResponse>? response;

            try
            {
                var result = _dbContext.Clothes
                    .TagWith(nameof(GetClotheByIdQueryHandler))
                    .Where(x => x.Id == request.Id && x.IsActive == true)
                    .ProjectTo<ClotheResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                response = new Result<ClotheResponse>
                {
                    Successful = true,
                    Item = result ?? new ClotheResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetClotheByIdQuery);
                response = new Result<ClotheResponse>
                {
                    Error = $"{ErrorsManager.GetClotheByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

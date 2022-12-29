// <copyright file="GetClothesQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.ClotheHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetClothesQuery, Result{ClotheResponse}}"/>.
    /// </summary>
    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, Result<ClotheResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetClothesQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetClothesQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetClothesQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetClothesQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetClothesQueryHandler(IApplicationDbContext dbContext, ILogger<GetClothesQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetClothesQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{ClotheResponse}}"/>.</returns>
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

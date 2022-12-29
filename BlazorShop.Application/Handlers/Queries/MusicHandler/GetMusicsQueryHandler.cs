// <copyright file="GetMusicsQueryHandler.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetMusicsQuery, Result{MusicResponse}}"/>.
    /// </summary>
    public class GetMusicsQueryHandler : IRequestHandler<GetMusicsQuery, Result<MusicResponse>>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _dbContext;

        /// <summary>
        /// An instance of <see cref="ILogger{GetMusicsQueryHandler}"/>.
        /// </summary>
        private readonly ILogger<GetMusicsQueryHandler> _logger;

        /// <summary>
        /// An instance of <see cref="IMapper"/>.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMusicsQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{GetMusicsQueryHandler}"/>.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetMusicsQueryHandler(IApplicationDbContext dbContext, ILogger<GetMusicsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// An implementation of the handler for <see cref="GetMusicsQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{Result{MusicResponse}}"/>.</returns>
        public Task<Result<MusicResponse>> Handle(GetMusicsQuery request, CancellationToken cancellationToken)
        {
            Result<MusicResponse>? response;

            try
            {
                var result = _dbContext.Musics
                    .TagWith(nameof(GetMusicsQueryHandler))
                    .ProjectTo<MusicResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                response = new Result<MusicResponse>
                {
                    Successful = true,
                    Items = result ?? new List<MusicResponse>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetMusicsQuery);
                response = new Result<MusicResponse>
                {
                    Error = $"{ErrorsManager.GetMusicsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                };
            }

            return Task.FromResult(response);
        }
    }
}

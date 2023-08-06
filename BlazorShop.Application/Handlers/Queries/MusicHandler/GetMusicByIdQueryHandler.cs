// <copyright file="GetMusicByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{GetMusicByIdQuery, MusicResponse}"/>.
    /// </summary>
    public class GetMusicByIdQueryHandler : IRequestHandler<GetMusicByIdQuery, Result<MusicResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMusicByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{GetMusicByIdQueryHandler}"/>.</param>
        /// <param name="mapper">Gets An instance of <see cref="IMapper"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public GetMusicByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetMusicByIdQueryHandler> logger, IMapper mapper)
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
        /// Gets An instance of <see cref="ILogger{GetMusicByIdQueryHandler}"/>.
        /// </summary>
        private ILogger<GetMusicByIdQueryHandler> Logger { get; }

        /// <summary>
        /// Gets An instance of <see cref="IMapper"/>.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="GetMusicByIdQuery"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Result{MusicResponse}"/>.</returns>
        public Task<Result<MusicResponse>> Handle(GetMusicByIdQuery request, CancellationToken cancellationToken)
        {
            Result<MusicResponse>? response;

            try
            {
                var result = this.DbContext.Musics
                    .TagWith(nameof(GetMusicByIdQueryHandler))
                    .ProjectTo<MusicResponse>(this.Mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                response = new Result<MusicResponse>
                {
                    Successful = true,
                    Item = result ?? new MusicResponse(),
                };
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.GetMusicByIdQuery);
                response = new Result<MusicResponse>
                {
                    Error = $"{ErrorsManager.GetMusicByIdQuery}. {ex.Message}. {ex.InnerException?.Message}",
                };
            }

            return Task.FromResult(response);
        }
    }
}

// <copyright file="UpdateMusicCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{UpdateMusicCommand, RequestResponse}"/>.
    /// </summary>
    public class UpdateMusicCommandHandler : IRequestHandler<UpdateMusicCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMusicCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{UpdateMusicCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public UpdateMusicCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateMusicCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{UpdateMusicCommandHandler}"/>.
        /// </summary>
        private ILogger<UpdateMusicCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="UpdateMusicCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Musics
                    .TagWith(nameof(UpdateMusicCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The music does not exists");
                }

                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.Author = request.Author;
                entity.DateRelease = request.DateRelease;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;
                entity.AccessLevel = request.AccessLevel;

                this.DbContext.Musics.Update(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.UpdateMusicCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

// <copyright file="DeleteMusicCommandHandler.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{DeleteMusicCommand, RequestResponse}"/>.
    /// </summary>
    public class DeleteMusicCommandHandler : IRequestHandler<DeleteMusicCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMusicCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{DeleteMusicCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public DeleteMusicCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteMusicCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{DeleteMusicCommandHandler}"/>.
        /// </summary>
        private ILogger<DeleteMusicCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="DeleteMusicCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Musics
                    .TagWith(nameof(DeleteMusicCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null)
                {
                    throw new Exception("The music does not exists");
                }

                this.DbContext.Musics.Remove(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.DeleteMusicCommand);
                response = RequestResponse.Failure($"{ErrorsManager.DeleteMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

// <copyright file="CreateMusicCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// An implementation of the <see cref="IRequestHandler{CreateMusicCommand, RequestResponse}"/>.
    /// </summary>
    public class CreateMusicCommandHandler : IRequestHandler<CreateMusicCommand, RequestResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMusicCommandHandler"/> class.
        /// </summary>
        /// <param name="dbContext">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        /// <param name="logger">Gets An instance of <see cref="ILogger{CreateMusicCommandHandler}"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if there is no logger provided.</exception>
        public CreateMusicCommandHandler(IApplicationDbContext dbContext, ILogger<CreateMusicCommandHandler> logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets An instance of <see cref="ILogger{CreateMusicCommandHandler}"/>.
        /// </summary>
        private ILogger<CreateMusicCommandHandler> Logger { get; }

        /// <summary>
        /// An implementation of the handler for <see cref="CreateMusicCommand"/>.
        /// </summary>
        /// <param name="request">The request object to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{RequestResponse}"/> representing the result of the asynchronous operation.</returns>
        public async Task<RequestResponse> Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = this.DbContext.Musics
                    .TagWith(nameof(CreateMusicCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity != null)
                {
                    throw new Exception("The entity already exists");
                }

                entity = new Music
                {
                    Title = request.Title,
                    Description = request.Description,
                    Author = request.Author,
                    DateRelease = request.DateRelease,
                    ImageName = request.ImageName,
                    ImagePath = request.ImagePath,
                };

                this.DbContext.Musics.Add(entity);
                await this.DbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ErrorsManager.CreateMusicCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

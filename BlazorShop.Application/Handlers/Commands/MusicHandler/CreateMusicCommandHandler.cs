// <copyright file="CreateMusicCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateMusicCommandHandler : IRequestHandler<CreateMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<CreateMusicCommandHandler> _logger;

        public CreateMusicCommandHandler(IApplicationDbContext dbContext, ILogger<CreateMusicCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Musics
                    .TagWith(nameof(CreateMusicCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity != null) throw new Exception("The entity already exists");

                entity = new Music
                {
                    Title = request.Title,
                    Description = request.Description,
                    Author = request.Author,
                    DateRelease = request.DateRelease,
                    ImageName = request.ImageName,
                    ImagePath = request.ImagePath,
                    AccessLevel = request.AccessLevel,
                };

                _dbContext.Musics.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.CreateMusicCommand);
                response = RequestResponse.Failure($"{ErrorsManager.CreateMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

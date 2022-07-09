// <copyright file="UpdateMusicCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateMusicCommandHandler : IRequestHandler<UpdateMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateMusicCommandHandler> _logger;

        public UpdateMusicCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateMusicCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
            RequestResponse? response;

            try
            {
                var entity = _dbContext.Musics
                    .TagWith(nameof(UpdateMusicCommandHandler))
                    .FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The music does not exists");

                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.Author = request.Author;
                entity.DateRelease = request.DateRelease;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;
                entity.AccessLevel = request.AccessLevel;

                _dbContext.Musics.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response = RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateMusicCommand);
                response = RequestResponse.Failure($"{ErrorsManager.UpdateMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }

            return response;
        }
    }
}

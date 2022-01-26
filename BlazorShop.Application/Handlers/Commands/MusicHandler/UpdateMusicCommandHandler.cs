namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    public class UpdateMusicCommandHandler : IRequestHandler<UpdateMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateMusicCommandHandler> _logger;

        public UpdateMusicCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateMusicCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateMusicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Musics.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.Author = request.Author;
                entity.DateRelease = request.DateRelease;
                entity.ImageName = request.ImageName;
                entity.ImagePath = request.ImagePath;
                entity.AccessLevel = request.AccessLevel;

                _dbContext.Musics.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the music");
                return RequestResponse.Error(new Exception("There was an error updating the music", ex));
            }
        }
    }
}

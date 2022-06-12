namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    public class DeleteMusicCommandHandler : IRequestHandler<DeleteMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteMusicCommandHandler> _logger;

        public DeleteMusicCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteMusicCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Musics.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The music does not exists");

                _dbContext.Musics.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteMusicCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteMusicCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

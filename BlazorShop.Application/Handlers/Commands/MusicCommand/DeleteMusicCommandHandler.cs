namespace BlazorShop.Application.Handlers.Commands.MusicCommand
{
    public class DeleteMusicCommandHandler : IRequestHandler<DeleteMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteMusicCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(DeleteMusicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Musics.FirstOrDefault(x => x.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                _dbContext.Musics.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the music", ex));
            }
        }
    }
}

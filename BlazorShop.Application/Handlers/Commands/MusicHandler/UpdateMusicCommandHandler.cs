namespace BlazorShop.Application.Handlers.Commands.MusicHandler
{
    public class UpdateMusicCommandHandler : IRequestHandler<UpdateMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateMusicCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

                _dbContext.Musics.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the music", ex));
            }
        }
    }
}

namespace BlazorShop.Application.Handlers.Commands.MusicCommand
{
    public class CreateMusicCommandHandler : IRequestHandler<CreateMusicCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateMusicCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> Handle(CreateMusicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Musics.FirstOrDefault(x => x.Id == request.Id);
                if (entity != null) throw new Exception("The entity already exists");

                entity = new Music
                {
                    Title = request.Title,
                    Description = request.Description,
                    Author = request.Author,
                    DateRelease = request.DateRelease,
                    ImageName = request.ImageName,
                    ImagePath = request.ImagePath,
                };

                _dbContext.Musics.Add(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the music", ex));
            }
        }
    }
}

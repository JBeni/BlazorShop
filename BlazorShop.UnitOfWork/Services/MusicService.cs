namespace BlazorShop.UnitOfWork.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MusicService> _logger;

        public MusicService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MusicService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<MusicResponse> GetAll()
        {
            try
            {
                var result = _unitOfWork.MusicRepository.GetAll();
                var musics = _mapper.Map<List<MusicResponse>>(result);
                return musics;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the musics.");
                return new List<MusicResponse>
                {
                    new MusicResponse
                    {
                        Error = $"There was an error while getting the musics. {ex.Message}. {ex.InnerException?.Message}"
                    }
                };
            }
        }

        public MusicResponse Get(int id)
        {
            try
            {
                var result = _unitOfWork.MusicRepository.Get(id);
                var music = _mapper.Map<MusicResponse>(result);
                return music ?? throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error while getting the music by id.");
                return new MusicResponse
                {
                    Error = $"There was an error while getting the music by id. {ex.Message}. {ex.InnerException?.Message}"
                };
            }
        }

        public RequestResponse AddMusic(MusicResponse music)
        {
            try
            {
                var entity = _unitOfWork.MusicRepository.Get(music.Id);
                if (entity != null) throw new ArgumentNullException();

                entity = new Music
                {
                    Title = music.Title,
                };

                _unitOfWork.MusicRepository.Add(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error creating the music");
                return RequestResponse.Failure($"There was an error creating the music. {ex.Message}. {ex.InnerException?.Message}");
            }
        }

        public RequestResponse UpdateMusic(MusicResponse music)
        {
            try
            {
                var entity = _unitOfWork.MusicRepository.Get(music.Id);
                if (entity == null) throw new ArgumentNullException();

                entity.Title = music.Title;

                _unitOfWork.MusicRepository.Update(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the music");
                return RequestResponse.Failure($"There was an error updating the music. {ex.Message}. {ex.InnerException?.Message}");
            }
        }

        public RequestResponse DeleteMusic(int id)
        {
            try
            {
                var entity = _unitOfWork.MusicRepository.Get(id);
                if (entity == null) throw new ArgumentNullException();

                _unitOfWork.MusicRepository.Delete(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error deleting the music");
                return RequestResponse.Failure($"There was an error deleting the music. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}

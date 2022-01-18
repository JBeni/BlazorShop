namespace BlazorShop.UnitOfWork.Services
{
    public class MusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MusicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                return new List<MusicResponse>
                {
                    new MusicResponse
                    {
                        Error = "There was an error while getting the musics... " + ex.Message ?? ex.InnerException.Message
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
                return new MusicResponse
                {
                    Error = "There was an error while getting the music by id... " + ex.Message ?? ex.InnerException.Message
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the music", ex));
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the music", ex));
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
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the music", ex));
            }
        }
    }
}

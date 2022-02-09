namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface IMusicService
    {
        Result<MusicResponse> GetAll();
        Result<MusicResponse> Get(int id);
        RequestResponse AddMusic(MusicResponse music);
        RequestResponse UpdateMusic(MusicResponse music);
        RequestResponse DeleteMusic(int id);
    }
}

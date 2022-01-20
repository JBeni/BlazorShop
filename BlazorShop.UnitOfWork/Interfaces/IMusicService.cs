namespace BlazorShop.UnitOfWork.Interfaces
{
    public interface IMusicService
    {
        List<MusicResponse> GetAll();
        MusicResponse Get(int id);
        RequestResponse AddMusic(MusicResponse music);
        RequestResponse UpdateMusic(MusicResponse music);
        RequestResponse DeleteMusic(int id);
    }
}

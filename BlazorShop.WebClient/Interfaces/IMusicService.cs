namespace BlazorShop.WebClient.Interfaces
{
    public interface IMusicService
    {
        Task<List<MusicResponse>> GetMusics();
        Task<MusicResponse> GetMusic(int id);
        Task<RequestResponse> AddMusic(MusicResponse music);
        Task<RequestResponse> UpdateMusic(MusicResponse music);
        Task<RequestResponse> DeleteMusic(int id);
    }
}

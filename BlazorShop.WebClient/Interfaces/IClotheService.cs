namespace BlazorShop.WebClient.Interfaces
{
    public interface IClotheService
    {
        event Action OnChange;

        Task<List<ClotheResponse>> GetClothes();
        Task<ClotheResponse> GetClothe(int id);
        Task<RequestResponse> AddClothe(ClotheResponse clothe);
        Task<RequestResponse> UpdateClothe(ClotheResponse clothe);
        Task<RequestResponse> DeleteClothe(int id);
    }
}

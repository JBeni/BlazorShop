namespace BlazorShop.WebClient.Services
{
    public interface IClotheService
    {
        Task<List<ClotheResponse>> GetClothes();
        Task<ClotheResponse> GetClothe(int id);
        Task AddClothe(ClotheResponse clothe);
        Task UpdateClothe(ClotheResponse clothe);
        Task DeleteClothe(int id);
    }
}

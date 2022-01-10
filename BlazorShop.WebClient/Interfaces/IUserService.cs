namespace BlazorShop.WebClient.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetUsers();
        Task<UserResponse> GetUser(int id);
        Task AddUser(UserResponse User);
        Task UpdateUser(UserResponse User);
        Task DeleteUser(int id);
    }
}

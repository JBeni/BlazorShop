namespace BlazorShop.WebClient.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetUsers();
        Task<UserResponse> GetUser(int id);
        Task<RequestResponse> AddUser(UserResponse user);
        Task<RequestResponse> UpdateUser(UserResponse user);
        Task<RequestResponse> UpdateUserEmail(UpdateUserEmailCommand user);
        Task<RequestResponse> DeleteUser(int id);
    }
}

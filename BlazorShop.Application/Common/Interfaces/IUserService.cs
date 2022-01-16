namespace BlazorShop.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<string>> GetUserRoleAsync(User user);
        List<UserResponse> GetUsers(GetUsersQuery query);
        UserResponse GetUserById(GetUserByIdQuery query);
        UserResponse GetUserByEmail(GetUserByEmailQuery query);
        Task<User> FindUserByIdAsync(int userId);
        Task<User> FindUserByEmailAsync(string email);
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);
        Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand user);
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);
        Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand user);
        Task<RequestResponse> DeleteUserAsync(int userId);
    }
}

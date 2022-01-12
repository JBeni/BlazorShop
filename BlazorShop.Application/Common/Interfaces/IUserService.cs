namespace BlazorShop.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<List<string>> GetUserRoleAsync(AppUser user);
        List<UserResponse> GetUsers(GetUsersQuery query);
        UserResponse GetUserById(GetUserByIdQuery query);
        UserResponse GetUserByEmail(GetUserByEmailQuery query);
        Task<AppUser> FindUserByIdAsync(int userId);
        Task<AppUser> FindUserByEmailAsync(string email);
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);
        Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand user);
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);
        Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand user);
        Task<RequestResponse> DeleteUserAsync(int userId);
    }
}

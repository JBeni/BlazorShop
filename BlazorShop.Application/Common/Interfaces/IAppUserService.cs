namespace BlazorShop.Application.Common.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUserResponse> GetUserRoleAsync(AppUser user);
        List<AppUserResponse> GetUsers(GetUsersQuery query);
        AppUserResponse GetUserById(GetUserByIdQuery query);
        AppUserResponse GetUserByEmail(GetUserByEmailQuery query);
        Task<AppUser> FindUserByIdAsync(int userId);
        Task<AppUser> FindUserByEmailAsync(string email);
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);
        Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand user);
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);
        Task<RequestResponse> DeleteUserAsync(int userId);
    }
}

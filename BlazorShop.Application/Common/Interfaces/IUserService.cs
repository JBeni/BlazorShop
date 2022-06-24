// <copyright file="IUserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<List<string>> GetUserRoleAsync(User user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        List<UserResponse> GetUsers(GetUsersQuery query);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        List<UserResponse> GetUsersInactive(GetUsersInactiveQuery query);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        UserResponse GetUserById(GetUserByIdQuery query);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        UserResponse GetUserByEmail(GetUserByEmailQuery query);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<User> FindUserByIdAsync(int userId);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<User> FindUserByEmailAsync(string email);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> ActivateUserAsync(ActivateUserCommand user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand user);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task<RequestResponse> DeleteUserAsync(int userId);
    }
}

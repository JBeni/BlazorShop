// <copyright file="IUserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Interfaces
{
    /// <summary>
    /// The service to interact with the user.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get the users.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<UserResponse>> GetUsers();

        /// <summary>
        /// Get the inactive users.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<List<UserResponse>> GetUsersInactive();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<UserResponse> GetUser(int id);

        /// <summary>
        /// Activate the user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> ActivateUser(int userId);

        /// <summary>
        /// Add an user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> AddUser(UserResponse user);

        /// <summary>
        /// Update the user.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateUser(UserResponse user);

        /// <summary>
        /// Update the user email.
        /// </summary>
        /// <param name="user">The user data.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> UpdateUserEmail(UpdateUserEmailCommand user);

        /// <summary>
        /// Delete the user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<RequestResponse> DeleteUser(int id);
    }
}
